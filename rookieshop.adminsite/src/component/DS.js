import React, { Fragment } from 'react'
import { Link } from "react-router-dom"
import "../categorymanage.css"
export default function DS() {
    return (
        <Fragment>
            <div className="our-services">
                <div className="container">
                    <div className="row">
                        <div className="col-sm-12 col-md-12 col-lg-3">
                            <div className="service">
                                <div className="media">
                                    <div className="service-card">
                                        <i className="fas fa-book mr-3" />
                                        <div className="media-body">

                                            <h5 className="mt-0"> <Link to='/products'>MANAGE BOOK</Link> </h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="col-sm-12 col-md-12 col-lg-3">
                            <div className="service">
                                <div className="media">
                                    <div className="service-card">
                                        <i class="fa fa-list-alt mr-3" aria-hidden="true"></i>
                                        <div className="media-body">
                                            <h5 className="mt-0"> <Link to='/customer'>MANAGE CATEGORY</Link></h5>
                                           
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="col-sm-12 col-md-12 col-lg-3">
                            <div className="service">
                                <div className="media">
                                    <div className="service-card">
                                        <i class="fas fa-box-open mr-3"></i>
                                        <div className="media-body">
                                            <h5 className="mt-0">
                                                <Link to='/orders'> MANAGE ORDER</Link>
                                               </h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className="col-sm-12 col-md-12 col-lg-3">
                            <div className="service">
                                <div className="media">
                                    <div className="service-card">
                                        <i className="fas fa-hands-helping mr-3" />
                                        <div className="media-body">
                                           
                                            <h5 className="mt-0">
                                                <Link to='/customer'>MANAGE CUSTOMER</Link>
                                            </h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </Fragment>
    )
}
