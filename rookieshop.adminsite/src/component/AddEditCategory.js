
import React, { useState, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { add_category, get_Category_by_Id, update_category } from "../actions/category"


export default function AddCategory({ match, history }) {
    const { id } = match.params;
    console.log(id);
    const isAddMode = !id;
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

    const handleSubmit = (e) => {
        e.preventDefault();
        var data = {
            Id: id,
            categoryName: Category.categoryName,
            categoryDescription: Category.categoryDescription,
        }
        return isAddMode
            ? dispatch(add_category(Category))
            : dispatch(update_category(data))

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
        if (categorySelected) {
            setCategory({
                categoryName: categorySelected.categoryName,
                categoryDescription: categorySelected.categoryDescription,
            })
        }
    }, [categorySelected])

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
                    <form onSubmit={handleSubmit}>
                        <div className="row">
                            <div className="col-lg-10">
                                <div className="card mb-3 mb-lg-5">
                                    <div className="card-header">
                                        <h4 className="card-header-title">Category information</h4>
                                    </div>
                                    <div className="card-body">
                                        <div className="form-group">
                                            <label htmlFor="productNameLabel" className="input-label">Name <i className="tio-help-outlined text-body ml-1" data-toggle="tooltip" data-placement="top" title data-original-title="Products are the goods or services you sell." /></label>
                                            <input type="text" className="form-control" name="categoryName" onChange={handleChange} value={Category.categoryName} id="categoryName" placeholder="Shirt, t-shirts, etc." aria-label="Shirt, t-shirts, etc." />
                                        </div>
                                        <div class="form-group">
                                            <textarea name="categoryDescription" id="categoryDescription" onChange={handleChange} value={Category.categoryDescription} rows="10" placeholder="Please type description of product"></textarea>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <button type="submit" class="btn btn-danger">{isAddMode? "Add":"Edit"} </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
                )
            }
        </div>
    )
}
