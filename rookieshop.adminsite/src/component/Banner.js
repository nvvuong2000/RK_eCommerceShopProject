import React, { Fragment, } from 'react'
import { Link } from "react-router-dom"
import { logout } from "../actions/user"
import { useDispatch, useSelector } from 'react-redux'
import DS from './DS';

export default function Banner(props) {
    const dispatch = useDispatch();
   
    const handleLogout = () => {
      
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
                                    <img className="z-index-2" src="https://upload.wikimedia.org/wikipedia/commons/1/14/Logo_Vavu.png" alt="Image Description" style={{ width: '8rem' }} />
                                    <input type="checkbox" id="nav" className="hidden" />
                                    <label htmlFor="nav" className="nav-toggle">
                                        <span />
                                        <span />
                                        <span />
                                    </label>
                                    <div className="wrapper">
                                        <ul className="menu">

                                            {!props.user.userId
                                                ?
                                                <Link to='/login' className="menu-item"><a href="#">Login</a></Link>
                                                :
                                                <Fragment>
                                                    <li className="menu-item"><a href="#">Hello: {props.user.userName}</a></li>
                                                    <li className="menu-item">
                                                        <Link to="/login" className="menu-item" onClick={handleLogout} className="menu-item">Log out</Link>
                                                    </li>
                                                </Fragment>
                                            }
                                        </ul>
                                    </div>
                                </nav>
                            </header>
                        </div>
                    </div>
                    {!props.user.userId
                        ?
                        ""
                        :
                        <DS />
                    }

                </div>

            </div>
        </div>
    )
}
