import React, { useEffect, useState } from 'react'
import { useSelector, useDispatch, } from "react-redux";
import { get_product_by_id } from "../actions/product"
import { get_category_list } from "../actions/category"
import ImagesProduct from './ImagesProduct';

export default function AddProduct(props) {

  const id = props.match.params.id;
  function handleChange(evt) {
    const value = evt.target.value;
    setItem({
      ...item,
      [evt.target.name]: value
    });
  }
  function handleSubmit(e) {
    e.preventDefault();

  }
  const dispatch = useDispatch();
  useEffect(() => {

    dispatch(get_product_by_id(id))
  }, [dispatch])

  useEffect(() => {

    dispatch(get_category_list())
  }, [])
  const product_selected = useSelector((state) => state.product.product_selected)
  const getCategoryList = useSelector((state) => state.category.categoryList)
  let categoryList = getCategoryList.data;
  let product = product_selected.data;
  console.log(product);
  const [item, setItem] = useState(product_selected?.data)

  useEffect(() => {
    
    setItem(product_selected?.data)
  }, [product_selected])
  const [categories, setCategories] = useState(categoryList);
  useEffect(() => {
    setCategories(categoryList)
  }, [categoryList]);
  console.log(item);
  return (

    <div>
      {
        item && (<div className="content container-fluid">
          {/* Page Header */}
          <div className="page-header">
            <div className="row align-items-center">
              <div className="col-sm mb-2 mb-sm-0">
                <nav aria-label="breadcrumb">
                  <ol className="breadcrumb breadcrumb-no-gutter">
                    <li className="breadcrumb-item"><a className="breadcrumb-link" href="#">Products</a></li>
                    <li className="breadcrumb-item active" aria-current="page">Add product
            </li>
                  </ol>
                </nav>
                <h1 className="page-header-title">Add product</h1>
              </div>
            </div>

            {/* End Row */}
          </div>
          {/* End Page Header */}
          <form>
            <div className="row">
              <div className="col-lg-10">
                {/* Card */}
                <div className="card mb-3 mb-lg-5">
                  {/* Header */}
                  <div className="card-header">
                    <h4 className="card-header-title">Product information</h4>
                  </div>
                  {/* End Header */}
                  {/* Body */}
                  <div className="card-body">
                    {/* Form Group */}
                    <div className="form-group">
                      <label htmlFor="productNameLabel" className="input-label">Name <i className="tio-help-outlined text-body ml-1" data-toggle="tooltip" data-placement="top" title data-original-title="Products are the goods or services you sell." /></label>
                      <input type="text" className="form-control" onChange={handleChange} value={item.productName} name="productName" id="productName" placeholder="Shirt, t-shirts, etc." aria-label="Shirt, t-shirts, etc." />
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
                        {/* Form Group */}
                        <div className="form-group">
                          <label htmlFor="categoryLabel" className="input-label">Status</label>
                          {/* Select */}
                          <select className="js-select2-custom custom-select" size={1} id="categoryLabel" tabIndex={-1} aria-hidden="true">

                            <option value={item.status} data-select2-id={156} selected={item.status === true}> On
                                    </option>
                            <option value={item.status} data-select2-id={156} selected={item.status === false}> Off
                                    </option>
                           


                          </select>
                          {/* End Select */}
                        </div>
                        {/* End Form Group */}
                      </div>
                      <div className="col-sm-6">
                        {/* Form Group */}
                        <div className="form-group">
                          <label htmlFor="categoryLabel" className="input-label">Category</label>
                          {/* Select */}
                          <select className="js-select2-custom custom-select" size={1} id="categoryLabel" tabIndex={-1} aria-hidden="true">
                            {
                              categories && categories.map(itemCate => {
                                return (
                                  <option value={itemCate.id} data-select2-id={156} selected={item.categoryId == itemCate.id}> {itemCate.categoryName}
                                  </option>
                                );
                              })
                            }

                          </select>
                          {/* End Select */}
                        </div>
                        {/* End Form Group */}
                      </div>
                      <div className="col-sm-6">
                        {/* Form Group */}
                        <div className="form-group">
                          <label htmlFor="SKULabel" className="input-label">Quan</label>
                          <input type="number" className="form-control" onChange={handleChange} value={item.stock} name="stock" id="stock" placeholder="eg. 10" aria-label="eg. 10" />
                        </div>
                        {/* End Form Group */}
                      </div>
                      <div className="col-sm-6">
                        {/* Form Group */}
                        <div className="form-group">
                          <label htmlFor="SKULabel" className="input-label">Price</label>
                          <input type="number" className="form-control" onChange={handleChange} value={item.unitPrice} name="unitPrice" id="unitPrice" placeholder="eg. 10.000" aria-label="eg. 10.000" />
                        </div>
                        {/* End Form Group */}
                      </div>
                    </div>
                    {/* End Row */}
                    <label className="input-label">Description <span className="input-label-secondary">(Optional)</span></label>
                    {/* Quill */}
                    <div className="quill-custom">
                      <div className="js-quill ql-container ql-snow" style={{ minHeight: '15rem' }} data-hs-quill-options="{
                    &quot;placeholder&quot;: &quot;Type your description...&quot;
                   }">
                        <div className="ql-editor ql-blank" data-gramm="false" contentEditable="true" name="description" >
                          <p onChange={handleChange} value={item.description}><br />{item.description}</p>
                        </div>
                        <div className="ql-clipboard" contentEditable="true" tabIndex={-1}>
                        </div>
                      </div>
                    </div>
                    {/* End Quill */}
                  </div>
                  {/* Body */}
                </div>
                {/* End Card */}
                <div className="card mb-3 mb-lg-5">
  {/* Header */}
  <div className="card-header">
    <h4 className="card-header-title">Media</h4>
    {/* Unfold */}
    <div className="hs-unfold">
      <a className="js-hs-unfold-invoker btn btn-sm btn-ghost-secondary" href="javascript:;" data-hs-unfold-options="{
                 &quot;target&quot;: &quot;#mediaDropdown&quot;,
                 &quot;type&quot;: &quot;css-animation&quot;
               }" data-hs-unfold-target="#mediaDropdown" data-hs-unfold-invoker>
        Add media from URL <i className="tio-chevron-down" />
      </a>
      <div id="mediaDropdown" className="hs-unfold-content dropdown-unfold dropdown-menu dropdown-menu-right mt-1 hs-unfold-hidden hs-unfold-content-initialized hs-unfold-css-animation animated" data-hs-target-height="97.6" data-hs-unfold-content data-hs-unfold-content-animation-in="slideInUp" data-hs-unfold-content-animation-out="fadeOut" style={{animationDuration: '300ms'}}>
        <a className="dropdown-item" href="javascript:;" data-toggle="modal" data-target="#addImageFromURLModal">
          <i className="tio-link dropdown-item-icon" /> Add image from URL
        </a>
        <a className="dropdown-item" href="javascript:;" data-toggle="modal" data-target="#embedVideoModal">
          <i className="tio-youtube-outlined dropdown-item-icon" /> Embed video
        </a>
      </div>
    </div>
    {/* End Unfold */}
  </div>
  {/* End Header */}
  {/* Body */}
  <div className="card-body">
    {/* Gallery */}
               <ImagesProduct list={item.pathName}/>
    {/* End Gallery */}
    {/* Dropzone */}
    <div id="attachFilesNewProjectLabel" className="js-dropzone dropzone-custom custom-file-boxed dz-clickable">
      <div className="dz-message custom-file-boxed-label">
        <img className="avatar avatar-xl avatar-4by3 mb-3" src="assets\svg\illustrations\browse.svg" alt="Image Description" />
        <h5 className="mb-1">Choose files to upload</h5>
        <p className="mb-2">or</p>
        <span className="btn btn-sm btn-primary">Browse files</span>
      </div>
    </div>
    {/* End Dropzone */}
  </div>
  {/* Body */}
</div>

              </div>
              <div className="col-lg-4">
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
