import React from 'react'

export default function OderDetails() {
    return (
        <div>
            <div className="content container-fluid">
  {/* Page Header */}
  <div className="page-header d-print-none">
    <div className="row align-items-center">
      <div className="col-sm mb-2 mb-sm-0">
        <nav aria-label="breadcrumb">
          <ol className="breadcrumb breadcrumb-no-gutter">
            <li className="breadcrumb-item"><a className="breadcrumb-link" href="#">Orders</a></li>
            <li className="breadcrumb-item active" aria-current="page">Order details</li>
          </ol>
        </nav>
        <div className="d-sm-flex align-items-sm-center">
          <h1 className="page-header-title">Order #32543</h1>
          <span className="badge badge-soft-success ml-sm-3">
            <span className="legend-indicator bg-success" />Paid
          </span>
          <span className="badge badge-soft-info ml-2 ml-sm-3">
            <span className="legend-indicator bg-info" />Fulfilled
          </span>
          <span className="ml-2 ml-sm-3">
            <i className="tio-date-range" /> Aug 17, 2020, 5:48 (ET)
          </span>
        </div>
        <div className="mt-2">
        </div>
      </div>
    </div>
  </div>
  {/* End Page Header */}
  <div className="row">
    <div className="col-lg-8 mb-3 mb-lg-0">
      {/* Card */}
      <div className="card mb-3 mb-lg-5">
        {/* Header */}
        <div className="card-header">
          <h4 className="card-header-title">Order details <span className="badge badge-soft-dark rounded-circle ml-1">4</span></h4>
        </div>
        {/* End Header */}
        {/* Body */}
        <div className="card-body">
          {/* Media */}
          <div className="media">
            <div className="avatar avatar-xl mr-3">
              <img className="img-fluid" src="assets\img\400x400\img26.jpg" alt="Image Description" />
            </div>
            <div className="media-body">
              <div className="row">
                <div className="col-md-6 mb-3 mb-md-0">
                  <a className="h5 d-block" href="ecommerce-product-details.html">Topman shoe in
                    green</a>
                  <div className="font-size-sm text-body">
                    <span>Gender:</span>
                    <span className="font-weight-bold">Women</span>
                  </div>
                  <div className="font-size-sm text-body">
                    <span>Color:</span>
                    <span className="font-weight-bold">Green</span>
                  </div>
                  <div className="font-size-sm text-body">
                    <span>Size:</span>
                    <span className="font-weight-bold">UK 7</span>
                  </div>
                </div>
                <div className="col col-md-2 align-self-center">
                  <h5>$21.00</h5>
                </div>
                <div className="col col-md-2 align-self-center">
                  <h5>2</h5>
                </div>
                <div className="col col-md-2 align-self-center text-right">
                  <h5>$42.00</h5>
                </div>
              </div>
            </div>
          </div>
          {/* End Media */}
          <hr />
          <div className="row justify-content-md-end mb-3">
            <div className="col-md-8 col-lg-7">
              <dl className="row text-sm-right">
                <dt className="col-sm-6">Amount paid:</dt>
                <dd className="col-sm-6">$65.00</dd>
              </dl>
              {/* End Row */}
            </div>
          </div>
          {/* End Row */}
        </div>
        {/* End Body */}
      </div>
      {/* End Card */}
    </div>
    <div className="col-lg-4">
      {/* Card */}
      <div className="card">
        {/* Header */}
        <div className="card-header">
          <h4 className="card-header-title">Customer</h4>
        </div>
        {/* End Header */}
        {/* Body */}
        <div className="card-body">
          <a className="media align-items-center" href="ecommerce-customer-details.html">
            <div className="avatar avatar-circle mr-3">
              <img className="avatar-img" src="assets\img\160x160\img10.jpg" alt="Image Description" />
            </div>
            <div className="media-body">
              <span className="text-body text-hover-primary">Amanda Harvey</span>
            </div>
            <div className="media-body text-right">
              <i className="tio-chevron-right text-body" />
            </div>
          </a>
          <hr />
          <a className="media align-items-center" href="ecommerce-customer-details.html">
          </a>
          <div className="d-flex justify-content-between align-items-center">
            <h5>Contact info</h5>
          </div>
          <ul className="list-unstyled list-unstyled-py-2">
            <li>
              <i className="tio-online mr-2" />
              ella@example.com
            </li>
            <li>
              <i className="tio-android-phone-vs mr-2" />
              +1 (609) 972-22-22
            </li>
          </ul>
          <hr />
          <div className="d-flex justify-content-between align-items-center">
            <h5>Shipping address</h5>
            <a className="link" href="javascript:;">Edit</a>
          </div>
          <span className="d-block">
            45 Roker Terrace<br />
            Latheronwheel<br />
            KW5 8NW, London<br />
            UK <img className="avatar avatar-xss avatar-circle ml-1" src="assets\vendor\flag-icon-css\flags\1x1\gb.svg" alt="Great Britain Flag" />
          </span>
          <hr />
        </div>
        {/* End Body */}
      </div>
      {/* End Card */}
    </div>
  </div>
  {/* End Row */}
</div>

        </div>
    )
}
