import React from 'react'

export default function CustomerDetails() {
    return (
        <div>
            <main id="content" role="main" className="main">
                <div className="content container-fluid">
                    <div className="row justify-content-lg-center">
                        <div className="col-lg-10">
                            {/* Nav */}
                            <div className="js-nav-scroller hs-nav-scroller-horizontal mb-5">
                                <span className="hs-nav-scroller-arrow-prev" style={{ display: 'none' }}>
                                    <a className="hs-nav-scroller-arrow-link" href="javascript:;">
                                        <i className="tio-chevron-left" />
                                    </a>
                                </span>
                                <span className="hs-nav-scroller-arrow-next" style={{ display: 'none' }}>
                                    <a className="hs-nav-scroller-arrow-link" href="javascript:;">
                                        <i className="tio-chevron-right" />
                                    </a>
                                </span>
                            </div>
                            {/* End Nav */}
                            <div className="row">
                                <div className="col-lg-4">
                                    {/* Sticky Block Start Point */}
                                    <div id="accountSidebarNav" style={{}} />
                                    {/* Card */}
                                    <div className="js-sticky-block card mb-3 mb-lg-5" data-hs-sticky-block-options="{
                 &quot;parentSelector&quot;: &quot;#accountSidebarNav&quot;,
                 &quot;breakpoint&quot;: &quot;lg&quot;,
                 &quot;startPoint&quot;: &quot;#accountSidebarNav&quot;,
                 &quot;endPoint&quot;: &quot;#stickyBlockEndPoint&quot;,
                 &quot;stickyOffsetTop&quot;: 20
               }" style={{}}>
                                        {/* Header */}
                                        <div className="card-header">
                                            <h5 className="card-header-title">Profile</h5>
                                        </div>
                                        {/* End Header */}
                                        {/* Body */}
                                        <div className="card-body">
                                            <ul className="list-unstyled list-unstyled-py-3 text-dark mb-3">
                                                <li className="py-0">
                                                    <small className="card-subtitle">About</small>
                                                </li>
                                                <li>
                                                    <i className="tio-user-outlined nav-icon" />
                    Ella Lauda
                  </li>
                                                <li className="pt-2 pb-0">
                                                    <small className="card-subtitle">Contacts</small>
                                                </li>
                                                <li>
                                                    <i className="tio-online nav-icon" />
                    ella@example.com
                  </li>
                                                <li>
                                                    <i className="tio-android-phone-vs nav-icon" />
                    +1 (609) 972-22-22
                  </li>
                                                <li>
                                                    <i className="tio-home nav-icon" />
                    HCM City
                  </li>
                                            </ul>
                                        </div>
                                        {/* End Body */}
                                    </div>
                                    {/* End Card */}
                                </div>
                                <div className="col-lg-8">
                                    {/* Card */}
                                    <div className="card mb-3 mb-lg-5">
                                        {/* Header */}
                                        <div className="card-header">
                                            <h5 className="card-header-title">Projects</h5>
                                        </div>
                                        {/* End Header */}
                                        {/* Table */}
                                        <div className="table-responsive">
                                            <table className="table table-borderless table-thead-bordered table-nowrap table-align-middle card-table">
                                                <thead className="thead-light">
                                                    <tr>
                                                        <th>Order</th>
                                                        <th style={{ width: '40%' }}>Status</th>
                                                        <th className="table-column-right-aligned">Total</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <div className="d-flex">
                                                                <span className="avatar avatar-xs avatar-soft-dark avatar-circle">
                                                                    <span className="avatar-initials">L</span>
                                                                </span>
                                                                <div className="ml-3">
                                                                    <h5 className="mb-0">#0102</h5>
                                                                    <small>4/17/2020</small>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td>
                                                            <div className="d-flex align-items-center">
                                                                <span className="mr-3">Đã nhận</span>
                                                                <div className="progress table-progress">
                                                                    <div className="progress-bar" role="progressbar" style={{ width: '0%' }} aria-valuenow={0} aria-valuemin={0} aria-valuemax={100}>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td className="table-column-right-aligned">123.548$</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        {/* End Table */}
                                    </div>
                                    {/* End Card */}
                                </div>
                            </div>
                            {/* End Row */}
                        </div>
                    </div>
                    {/* End Row */}
                </div>
                {/* Footer */}
            </main>

        </div>
    )
}
