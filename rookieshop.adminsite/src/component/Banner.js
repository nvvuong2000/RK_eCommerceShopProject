import React, { Fragment, } from 'react'
import { Link } from "react-router-dom"
import {logout} from "../actions/user"
import { useDispatch ,useSelector} from 'react-redux'

export default function Banner(props) {
    const dispatch = useDispatch();
    const handleLogout =()=>{
        dispatch(logout());
    }
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
                                            {!props.user.userId
                                                ?
                                                <Link to='/login' className="menu-item"><a href="#">Login</a></Link>
                                                :
                                                <Fragment>
                                                    <li className="menu-item"><a href="#">Hello: {props.user.userName}</a></li>
                                                    <button class="btn btn-danger" onClick={handleLogout} to='/login' className="menu-item"><a href="#">Log out</a></button>
                                                </Fragment>

                                            }

                                        </ul>
                                    </div>
                                </nav>
                            </header>
                        </div>
                    </div>
                    {/* End of Content Wrapper */}
                </div>

            </div>
        </div>
    )
}
