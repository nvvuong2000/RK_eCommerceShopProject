import React from 'react'
import {Link} from "react-router-dom"

export default function Banner(props) {
    console.log(props);
    return (
        <div>
            <div>

                <div id="wrapper">

                    <div id="content-wrapper" className="d-flex flex-column">

                        <div id="content">


                            <header className="header">
                                <nav className="navbar">
                                    <a className="brand" href="#">Brand</a>
                                    <input type="checkbox" id="nav" className="hidden" />
                                    <label htmlFor="nav" className="nav-toggle">
                                        <span />
                                        <span />
                                        <span />
                                    </label>
                                    <div className="wrapper">
                                        <ul className="menu">
                                            <Link to='/products' className="menu-item"><a href="#">Products</a></Link>
                                            <Link to='/orders' className="menu-item"><a href="#">Orders</a></Link>
                                            <Link to='/customer' className="menu-item"><a href="#">Customer</a></Link>
                                            {props.user == null ? 
                                            <Link to='/login' className="menu-item"><a href="#">Login</a></Link> 
                                            : 
                                            <li className="menu-item"><a href="#">Hello: {props.user.userName}</a></li>
                                            }
                                     
                                        </ul>
                                    </div>
                                </nav>
                            </header>

                            {/* Content */}
                            <main id="content" role="main" className="main">
                                {/*  Component ở đây */}
                                {/* <Orders/> */}


                                <div className="footer">
                                    <div className="row justify-content-between align-items-center">
                                        <div className="col">
                                            <p className="font-size-sm mb-0">© Front. <span className="d-none d-sm-inline-block">2021.</span></p>
                                        </div>
                                    </div>
                                </div>
                                {/* End Footer */}
                            </main>
                        </div>
                    </div>
                    {/* End of Content Wrapper */}
                </div>

            </div>
        </div>
    )
}
