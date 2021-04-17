import React from 'react'

export default function Error() {
    return (
        <div>
          <div className="content container-fluid">
  <div className="row align-items-sm-center py-sm-10">
    <div className="col-sm-6">
      <div className="text-center text-sm-right mr-sm-4 mb-5 mb-sm-0">
        <img className="w-60 w-sm-100 mx-auto" src="../../public/asset/svg/think.svg" alt="Image Description" style={{maxWidth: '15rem'}} />
      </div>
    </div>
    <div className="col-sm-6 col-md-4 text-center text-sm-left">
      <h1 className="display-1 mb-0">404</h1>
      <p className="lead">Sorry, the page you're looking for cannot be found.</p>
      <a className="btn btn-primary" href="index.html">Go back to the App</a>
    </div>
  </div>
  {/* End Row */}
</div>

        </div>
    )
}
