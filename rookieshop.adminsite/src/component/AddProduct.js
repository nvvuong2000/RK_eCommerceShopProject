import React from 'react'

export default function AddProduct() {
    return (
        <div>
          <div className="content container-fluid">
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
            <input type="text" className="form-control" name="productName" id="productNameLabel" placeholder="Shirt, t-shirts, etc." aria-label="Shirt, t-shirts, etc." />
          </div>
          {/* End Form Group */}
          <div className="row">
            <div className="col-sm-6">
              {/* Form Group */}
              <div className="form-group">
                <label htmlFor="categoryLabel" className="input-label">Provider</label>
                {/* Select */}
                <select className="js-select2-custom custom-select" size={1} id="categoryLabel" tabIndex={-1} aria-hidden="true">
                  <option value="Clothing" data-select2-id={156}>Nike
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
                  <option value="Clothing" data-select2-id={156}>Clothing
                  </option>
                </select>
                {/* End Select */}
              </div>
              {/* End Form Group */}
            </div>
            <div className="col-sm-6">
              {/* Form Group */}
              <div className="form-group">
                <label htmlFor="SKULabel" className="input-label">Quan</label>
                <input type="text" className="form-control" name="quan" id="quan" placeholder="eg. 10" aria-label="eg. 10" />
              </div>
              {/* End Form Group */}
            </div>
            <div className="col-sm-6">
              {/* Form Group */}
              <div className="form-group">
                <label htmlFor="SKULabel" className="input-label">Price</label>
                <input type="text" className="form-control" name="quan" id="quan" placeholder="eg. 10.000" aria-label="eg. 10.000" />
              </div>
              {/* End Form Group */}
            </div>
          </div>
          {/* End Row */}
          <label className="input-label">Description <span className="input-label-secondary">(Optional)</span></label>
          {/* Quill */}
          <div className="quill-custom">
            <div className="js-quill ql-container ql-snow" style={{minHeight: '15rem'}} data-hs-quill-options="{
                    &quot;placeholder&quot;: &quot;Type your description...&quot;
                   }">
              <div className="ql-editor ql-blank" data-gramm="false" contentEditable="true" data-placeholder="Type your description...">
                <p><br /></p>
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
      {/* Card */}
      <div className="card mb-3 mb-lg-5">
        {/* Header */}
        <div className="card-header">
          <h4 className="card-header-title">Media</h4>
          {/* Unfold */}
          <div className="hs-unfold">
            <div id="mediaDropdown" className="hs-unfold-content dropdown-unfold dropdown-menu dropdown-menu-right mt-1 hs-unfold-hidden hs-unfold-content-initialized hs-unfold-css-animation animated hs-unfold-reverse-y" data-hs-target-height="97.6" data-hs-unfold-content data-hs-unfold-content-animation-in="slideInUp" data-hs-unfold-content-animation-out="fadeOut" style={{animationDuration: '300ms'}}>
              <a className="dropdown-item" href="javascript:;" data-toggle="modal" data-target="#addImageFromURLModal">
                <i className="tio-link dropdown-item-icon" /> Add image from URL
              </a>
              <a className="dropdown-item" href="javascript:;" data-toggle="modal" data-target="#embedVideoModal">
                <i className="tio-youtube-outlined dropdown-item-icon" /> Embed
                video
              </a>
            </div>
          </div>
          {/* End Unfold */}
        </div>
        {/* End Header */}
        {/* Body */}
        <div className="card-body">
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
      {/* End Card */}
    </div>
    <div className="col-lg-4">
    </div>
  </div>
  {/* End Row */}
</div>

        </div>
    )
}
