import React, { useEffect, useState } from 'react'
import { useSelector, useDispatch, } from "react-redux";
import { get_product_by_id, add_product, update_product } from "../actions/product"
import { get_category_list } from "../actions/category"
import { get_provider_list } from "../actions/provider"
import ImagesProduct from './ImagesProduct';
import { Formik, useFormik } from "formik";
import * as Yup from "yup";
export default function AddProduct({ match }) {

  const dispatch = useDispatch();

  const { id } = match.params;

  const isAddMode = isNaN(id);
  
  const getCategoryList = useSelector((state) => state.category.categoryList)

  let categoryList = getCategoryList;

  const getProviderList = useSelector((state) => state.provider.providerList)

  let providerList = getProviderList;

  const product_selected = useSelector((state) => state.product.product_selected)
  
  const [product, setProduct] = useState({
    productID: 0,
    providerId: 0,
    categoryId: 0,
    productName: "",
    stock: 0,
    unitPrice: 0,
    description: "",
    isNew: true,
    status: true,
    pathName: []
  });
  
  const [fileImages, setFileImages] = useState([]);

  const [formData, setFormData] = useState(new FormData());

  
  useEffect(() => {
    
    dispatch(get_category_list());

    dispatch(get_provider_list());

    if (!isAddMode) {
    
      dispatch(get_product_by_id(id));
    
    }

  }, []);
  
  useEffect(() => {
    if (isAddMode == false && product_selected) {
      setProduct({
        productID: product_selected.id,
       
        providerId: product_selected.providerId,
       
        categoryId: product_selected.categoryId,
       
        productName: product_selected.productName,
       
        stock: product_selected.stock,
       
        unitPrice: product_selected.unitPrice,
       
        description: product_selected.description,
       
        isNew: product_selected.isNew,
       
        status: product_selected.status,
       
        pathName: product_selected.pathName
      })
    }
  }, [product_selected]);
  
  const  handleChange=(evt)=> {
    const value = evt.target.value;
   
    setProduct({
     
      ...product,
     
      [evt.target.name]: value
   
    });
  }
  const handleChangeFileImages = (e) => {
    const files = [];
   
    const formData = new FormData();
   
    if (e.target.files) {
      for (let i = 0; i < e.target.files.length; i++) {
   
        files.push(URL.createObjectURL(e.target.files[i]));
   
        formData.append("FormFiles", e.target.files[i], e.target.files[i].name);
      }
   
      setFileImages(files);

      setProduct({ ...product, pathName: files })
    }
      setFormData(formData);
  }
  const formik = useFormik({
    //When set to true, the form will reinitialize every time the initialValues prop changes. 
    enableReinitialize: true,
    initialValues: {
      productID: product.id,
      providerId: product.providerId,
      categoryId: product.categoryId,
      productName: product.productName,
      stock: product.stock,
      unitPrice: product.unitPrice,
      description: product.description,
      isNew: product.isNew,
      status: product.status,
      pathName: product.pathName
    },
    validationSchema: Yup.object({
      providerId: Yup.number().required().positive("* Please choose Provider").integer(),
      categoryId: Yup.number().required().positive("* Please choose Category").integer(),
      stock: Yup.number().required().positive("* Please type quantity").integer().min(0),
      unitPrice: Yup.number().required().positive("* Please type unit price").integer().min(0),
      status: Yup.boolean().required("* Please choose status"),
      isNew: Yup.boolean().required(),
      productName: Yup.string()
        .min(5, "* Mininum 5 characters")
        .required("* Required!"),
      description: Yup.string()
        .min(15, "* Description for product required mininum 15 characters")
        .required("* Description is Required!")
        .matches(
          /\s*\S.*/,
          "* Product Description cannot contain only blank spaces"
        ),
      pathName: Yup.array()
        .required("* Required")
        .min(1, "* Require at least an image for product")
    }),
    onSubmit: () => {

      const formDataSubmit = formData;
      formDataSubmit.append('productID', product.productID);
      formDataSubmit.append('productName', product.productName);
      formDataSubmit.append('description', product.description);
      formDataSubmit.append('unitPrice', product.unitPrice);
      formDataSubmit.append('stock', product.stock);
      formDataSubmit.append('isNew', product.isNew);
      formDataSubmit.append('status', product.status);
      formDataSubmit.append('categoryID', parseInt(product.categoryId));
      formDataSubmit.append('providerID', product.providerId);
     
      return isAddMode
        ? dispatch(add_product(formDataSubmit))
        : dispatch(update_product(formDataSubmit))


    }
  });

  return (

    <div>
      {
        (<div className="content container-fluid">
          <div className="page-header">
            <div className="row align-items-center">
              <div className="col-sm mb-2 mb-sm-0">
                <nav aria-label="breadcrumb">
                  <ol className="breadcrumb breadcrumb-no-gutter">
                    <li className="breadcrumb-item"><a className="breadcrumb-link" href="#">Products</a></li>
                    <li className="breadcrumb-item active" aria-current="page">{isAddMode ? "Add Product" : "Edit Product"}
                    </li>
                  </ol>
                </nav>
                <h1 className="page-header-title">{isAddMode ? "Add Product" : "Edit Product"}</h1>
              </div>
            </div>
          </div>

          <Formik>
            <form onSubmit={formik.handleSubmit}>
              <div className="row">
                <div className="col-lg-10">
                  <div className="card mb-3 mb-lg-5">
                    <div className="card-header">
                      <h4 className="card-header-title">Product information</h4>
                    </div>
                    <div className="card-body">
                      <div className="form-group">
                        <label htmlFor="productNameLabel" className="input-label">Name </label>
                        <input type="text" className="form-control" onChange={handleChange} value={formik.values.productName} name="productName" id="productName" placeholder="Shirt, t-shirts, etc." aria-label="Shirt, t-shirts, etc." />
                        {formik.errors.productName && formik.touched.productName && (
                          <p style={{ color: "red" }}>{formik.errors.productName}</p>
                        )}
                      </div>
                      <div className="row">

                        <div className="col-sm-6">
                          <div className="form-group">
                            <label htmlFor="categoryLabel" className="input-label">Provider</label>

                            <select className="js-select2-custom custom-select" size={1} id="categoryLabel" name="providerId" tabIndex={-1} aria-hidden="true" onChange={handleChange} >
                              <option value="" selected disabled hidden>Choose here</option>
                              {
                                providerList && providerList.map((itemProvider,index) => {
                                  return (
                                    <option key={index} value={itemProvider.providerId} data-select2-id={156} selected={formik.values.providerId == itemProvider.providerId}> {itemProvider.providerName}
                                    </option>
                                  );
                                })
                              }
                            </select>
                            {formik.errors.providerId && formik.touched.providerId && (
                              <p style={{ color: "red" }}>{formik.errors.providerId}</p>
                            )}


                          </div>
                        </div>

                        <div className="col-sm-6">
                          <div className="form-group">
                            <label htmlFor="categoryLabel" className="input-label">Category</label>

                            <select className="js-select2-custom custom-select" size={1} id="categoryLabel" name="categoryId" tabIndex={-1} aria-hidden="true" onChange={handleChange} >
                              <option value="" selected disabled hidden>Choose here</option>
                              {
                                categoryList && categoryList.map((itemCate,index) => {
                                  return (
                                    <option key={index} value={itemCate.id} selected={formik.values.categoryId == itemCate.id}> {itemCate.categoryName}
                                    </option>
                                  );
                                })
                              }

                            </select>
                            {formik.errors.categoryId && formik.touched.categoryId && (
                              <p style={{ color: "red" }}>{formik.errors.categoryId}</p>
                            )}


                          </div>
                        </div>
                        <div className="col-sm-6">
                          <div className="form-group">
                            <label htmlFor="SKULabel" className="input-label">Quan</label>
                            <input type="number" className="form-control" onChange={handleChange} value={formik.values.stock} name="stock" id="stock" placeholder="eg. 10" aria-label="eg. 10" />
                            {formik.errors.stock && formik.touched.stock && (
                              <p style={{ color: "red" }}>{formik.errors.stock}</p>
                            )}
                          </div>
                        </div>
                        <div className="col-sm-6">
                          <div className="form-group">
                            <label htmlFor="SKULabel" className="input-label">Price</label>
                            <input type="number" className="form-control" onChange={handleChange} value={formik.values.unitPrice} name="unitPrice" id="unitPrice" placeholder="eg. 10.000" aria-label="eg. 10.000" />
                            {formik.errors.unitPrice && formik.touched.unitPrice && (
                              <p style={{ color: "red" }}>{formik.errors.unitPrice}</p>
                            )}
                          </div>
                        </div>



                        {!isAddMode ?
                          <div className="col-sm-6">
                            <div className="form-group">
                              <label htmlFor="categoryLabel" className="input-label">Status</label>
                              <select className="js-select2-custom custom-select" name="status" onChange={handleChange} size={1} id="categoryLabel" tabIndex={-1} aria-hidden="true">

                                <option key={1} value={true} data-select2-id={156} selected={formik.values.status === true}> On
                                    </option>
                                <option key={2} value={false} data-select2-id={156} selected={formik.values.status === false}> Off
                                    </option>
                              </select>    </div>
                          </div> : ""}




                        {!isAddMode ?
                          <div className="col-sm-6">
                            <div className="form-group">
                              <label htmlFor="categoryLabel" className="input-label">is New</label>
                              <select className="js-select2-custom custom-select" name="isNew" onChange={handleChange} size={1} id="categoryLabel" tabIndex={-1} aria-hidden="true">

                                <option value={true} key={1} data-select2-id={156} selected={formik.values.isNew === true}> On
                                    </option>
                                <option value={false} key={2} data-select2-id={156} selected={formik.values.isNew === false}> Off
                                    </option>
                              </select>
                            </div>
                          </div> : ""
                        }
                      </div>


                      <label className="input-label">Description <span className="input-label-secondary">(Optional)</span></label>
                      <div className="quill-custom">

                        <div className="form-group" >
                          <textarea onChange={handleChange} value={formik.values.description} name="description" rows="10" placeholder="Please type description of product"></textarea>
                          {formik.errors.description && formik.touched.description && (
                            <p style={{ color: "red" }}>{formik.errors.description}</p>
                          )}
                        </div>

                      </div>
                    </div>
                  </div>
                  <div className="card mb-3 mb-lg-5">
                    <div className="card-header">
                      <h4 className="card-header-title">Media</h4>
                      <div className="hs-unfold">
                        <a className="js-hs-unfold-invoker btn btn-sm btn-ghost-secondary" href="#">
                          <h5 className="mb-1">Choose files to upload</h5>
                        </a>
                      </div>
                    </div>

                    <input type='file' multiple className="form-control" onChange={handleChangeFileImages} />

                    <div className="card-body">
                      <ImagesProduct list={product.pathName} />

                    </div>
                    {formik.errors.pathName && formik.touched.pathName && (
                      <p style={{ color: "red" }}>{formik.errors.pathName}</p>
                    )}

                  </div>

                </div>
                <div className="col-lg-4">
                  <button type="submit" className="btn btn-danger">Submit</button>
                </div>
              </div>
              {/* End Row */}
            </form>
          </Formik>
        </div>
        )
      }
    </div>
  )
}
