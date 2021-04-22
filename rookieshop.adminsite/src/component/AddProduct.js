import React, { useEffect, useState } from 'react'
import { useSelector, useDispatch, } from "react-redux";
import { get_product_by_id, add_product,update_product } from "../actions/product"
import { get_category_list, update_category } from "../actions/category"
import ImagesProduct from './ImagesProduct';

export default function AddProduct({ match }) {

  const { id } = match.params;

  const isAddMode = isNaN(id);
  console.log(isAddMode);
  const dispatch = useDispatch();


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
    rating: 0,
    pathName: []
  });

  const [fileImages, setFileImages] = useState([]);

  const [formData, setFormData] = useState(new FormData());

  function handleChange(evt) {
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
        console.log(e.target.files[i], e.target.files[i].name)
        formData.append("FormFiles", e.target.files[i], e.target.files[i].name);
        console.log(e.target.files[i], e.target.files[i].name)
      }
      setFileImages(files);

      setProduct({ ...product, pathName: files })
    }
    setFormData(formData);
  }

  const handleSubmit = async (e) => {
    e.preventDefault();
    const formDataSubmit = formData;
    console.log(product);
    formDataSubmit.append('productID', product.productID);
    formDataSubmit.append('productName', product.productName);
    formDataSubmit.append('description', product.description);
    formDataSubmit.append('unitPrice', product.unitPrice);
    formDataSubmit.append('stock', product.stock);
    formDataSubmit.append('isNew', product.isNew);
    formDataSubmit.append('status', product.status);
    formDataSubmit.append('categoryID', parseInt(product.categoryId));
    formDataSubmit.append('providerID', 3);
    return isAddMode
      ? dispatch(add_product(formDataSubmit))
      : dispatch(update_product(formDataSubmit))

    
  };
  useEffect(() => {
    if (!isAddMode) {
      dispatch(get_product_by_id(id))
    }

  }, [])

  useEffect(() => {
    dispatch(get_category_list())
  }, [])

  const getCategoryList = useSelector((state) => state.category.categoryList)

  let categoryList = getCategoryList.data;

  console.log(categoryList);

  const product_selected = useSelector((state) => state.product.product_selected.data)
  console.log(product_selected);
  useEffect(() => {
    if (isAddMode==false && product_selected) {
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



          <form onSubmit={handleSubmit}>
            <div className="row">
              <div className="col-lg-10">
                <div className="card mb-3 mb-lg-5">
                  <div className="card-header">
                    <h4 className="card-header-title">Product information</h4>
                  </div>
                  <div className="card-body">
                    <div className="form-group">
                      <label htmlFor="productNameLabel" className="input-label">Name <i className="tio-help-outlined text-body ml-1" data-toggle="tooltip" data-placement="top" title data-original-title="Products are the goods or services you sell." /></label>
                      <input type="text" className="form-control" onChange={handleChange} value={product.productName} name="productName" id="productName" placeholder="Shirt, t-shirts, etc." aria-label="Shirt, t-shirts, etc." />
                    </div>
                    <div className="row">
                      {/* <div className="col-sm-6">
                      
                        <div className="form-group">
                          <label htmlFor="categoryLabel" className="input-label">Provider</label>
                        
                          <select className="js-select2-custom custom-select" size={1} id="categoryLabel" tabIndex={-1} aria-hidden="true">
                            <option value="Clothing" data-select2-id={156}>
                            </option>
                          </select>
                      
                        </div>
                      
                      </div> */}
                      <div class="col-sm-6">
                        <div className="form-group">
                          <label htmlFor="categoryLabel" className="input-label">Status</label>

                          {!isAddMode ? <select className="js-select2-custom custom-select" name="status" onChange={handleChange} size={1} id="categoryLabel" tabIndex={-1} aria-hidden="true">

                            <option value={product.status} data-select2-id={156} selected={product.status === true}> On
                                    </option>
                            <option value={product.status} data-select2-id={156} selected={product.status === false}> Off
                                    </option>
                          </select> : ""}

                        </div>
                      </div>
                      <div className="col-sm-6">
                        <div className="form-group">
                          <label htmlFor="categoryLabel" className="input-label">Category</label>
                          
                          <select className="js-select2-custom custom-select" size={1} id="categoryLabel" name="categoryId" tabIndex={-1} aria-hidden="true" onChange={handleChange} >
                            {
                              categoryList && categoryList.map(itemCate => {
                                return (
                                  <option value={itemCate.id} data-select2-id={156} selected={itemCate.categoryId == itemCate.id}> {itemCate.categoryName}
                                  </option>
                                );
                              })
                            }

                          </select>
                          

                        </div>
                      </div>
                      <div className="col-sm-6">
                        <div className="form-group">
                          <label htmlFor="SKULabel" className="input-label">Quan</label>
                          <input type="number" className="form-control" onChange={handleChange} value={product.stock} name="stock" id="stock" placeholder="eg. 10" aria-label="eg. 10" />
                        </div>
                      </div>
                      <div className="col-sm-6">
                        <div className="form-group">
                          <label htmlFor="SKULabel" className="input-label">Price</label>
                          <input type="number" className="form-control" onChange={handleChange} value={product.unitPrice} name="unitPrice" id="unitPrice" placeholder="eg. 10.000" aria-label="eg. 10.000" />
                        </div>
                      </div>
                    </div>
                    <label className="input-label">Description <span className="input-label-secondary">(Optional)</span></label>
                    <div className="quill-custom">

                      <div className="form-group" >
                        <textarea onChange={handleChange} value={product.description} name="description" rows="10" placeholder="Please type description of product"></textarea>
                      </div>

                    </div>
                  </div>
                </div>
                <div className="card mb-3 mb-lg-5">
                  <div className="card-header">
                    <h4 className="card-header-title">Media</h4>
                    <div className="hs-unfold">
                      <a className="js-hs-unfold-invoker btn btn-sm btn-ghost-secondary" href="javascript:;">
                        <h5 className="mb-1">Choose files to upload</h5>
                      </a>
                    </div>
                  </div>
                 
                  <input type='file' multiple className="form-control" onChange={handleChangeFileImages} />
                  <div className="card-body">
                    <ImagesProduct list={product.pathName} />
                  </div>
                
                </div>

              </div>
              <div className="col-lg-4">
                <button type="submit" className="btn btn-danger">Submit</button>
              </div>
            </div>
            {/* End Row */}
          </form>
        </div>
        )
      }
    </div>
  )
}
