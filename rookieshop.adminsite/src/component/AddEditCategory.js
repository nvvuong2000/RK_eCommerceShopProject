
import React, { useState, useEffect } from "react";
import { Formik, useFormik } from "formik";
import * as Yup from "yup";
import { useDispatch, useSelector } from "react-redux";
import { add_category, get_Category_by_Id, update_category } from "../actions/category"


export default function AddCategory({ match, history }) {
    const { id } = match.params;

    const isAddMode = isNaN(id);

    const dispatch = useDispatch();

    const [Category, setCategory] = useState({
        categoryName: "",
        categoryDescription: "",
    });

    const handleChange = (e) => {
        const value = e.target.value;
        setCategory({
            ...Category,
            [e.target.name]: value
        });
    }


    useEffect(() => {

        dispatch(get_Category_by_Id(id))
    }, []);

    useEffect(() => {
        if (!isAddMode) {
            dispatch(get_Category_by_Id(id))
        }
    }, []);

    const categorySelected = useSelector(state => state.category.categoryselected.data);

    useEffect(() => {
        if (isAddMode == false && categorySelected) {
            setCategory({
                categoryName: categorySelected.categoryName,
                categoryDescription: categorySelected.categoryDescription,
            })

        }
    }, [categorySelected]);

    const formik = useFormik({
        //When set to true, the form will reinitialize every time the initialValues prop changes. 
        enableReinitialize: true, // important
        initialValues: {
            categoryName: Category.categoryName,
            categoryDescription: Category.categoryDescription,
        },
        validationSchema: Yup.object({
            categoryName: Yup.string()
                .min(3, "Category Name required mininum 3 characters")
                .required(" Category Name is Required!")
                .matches(/\s*\S.*/, '* Category Name cannot contain only blank spaces'),
            categoryDescription: Yup.string()
                .min(15, "Category Name required mininum 15 characters")
                .required("Category Description is Required!")
                .matches(/\s*\S.*/, '* Category Description cannot contain only blank spaces'),
        }),
        onSubmit: () => {
            
            var data = {
                Id: id,
                categoryName: Category.categoryName,
                categoryDescription: Category.categoryDescription,
            }
            
            return isAddMode
                ? dispatch(add_category(Category))
                : dispatch(update_category(data))
        }
    });

    return (
        <div>
            {
                Category && (<div className="content container-fluid">
                    {/* Page Header */}
                    <div className="page-header">
                        <div className="row align-items-center">
                            <div className="col-sm mb-2 mb-sm-0">
                                <nav aria-label="breadcrumb">
                                    <ol className="breadcrumb breadcrumb-no-gutter">
                                        <li className="breadcrumb-item"><a className="breadcrumb-link" href="#">Category</a></li>
                                        <li className="breadcrumb-item active" aria-current="page">{isAddMode ? "Add Category" : "Edit Category"}</li>
                                    </ol>
                                </nav>
                                <h1 className="page-header-title">{isAddMode ? "Add Category" : "Edit Category"}</h1>
                            </div>
                        </div>
                        {/* End Row */}
                    </div>
                    {/* End Page Header */}
                    <Formik enableReinitialize>
                        <form onSubmit={formik.handleSubmit}>
                            <div className="row">
                                <div className="col-lg-10">
                                    <div className="card mb-3 mb-lg-5">
                                        <div className="card-header">
                                            <h4 className="card-header-title">Category information</h4>
                                        </div>
                                        <div className="card-body">
                                            <div className="form-group">
                                                <input type="text" className="form-control" name="categoryName" value={formik.values.categoryName} onChange={handleChange} id="categoryName" placeholder="Shirt, t-shirts, etc." aria-label="Shirt, t-shirts, etc." />

                                                {formik.errors.categoryName && formik.touched.categoryName && (
                                                    <p style={{ color: "red" }}>{formik.errors.categoryName}</p>
                                                )}
                                            </div>
                                            <div class="form-group">
                                                <textarea name="categoryDescription" id="categoryDescription" onChange={handleChange} value={formik.values.categoryDescription} rows="10" placeholder="Please type description of product"></textarea>
                                                {formik.errors.categoryDescription &&
                                                    formik.touched.categoryDescription && (
                                                        <p style={{color:"red"}}>{formik.errors.categoryDescription}</p>
                                                    )}
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <button type="submit" class="btn btn-danger">{isAddMode ? "Add" : "Edit"} </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </Formik>

                </div>
                )
            }
        </div>
    )
}
