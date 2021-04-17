import React, { Fragment } from 'react'

import Orders from "./Orders"
import Product from './Product'
import Customer from './Customer'
import CustomerDetails from './CustomerDetails'
import AddProduct from './AddProduct'
import OrderDetails from './OderDetails'
import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";
import Login from './Login'

export default function Index() {
  return (
   
    <Fragment>
  

      <Router>
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
                      
                      <li className="menu-item"><a href="#">Hello: Admin</a></li>

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
        <Switch>
          
          <Route exact path="/products" component={Product} />
          <Route exact path="/orders" component={Orders} />
          <Route exact path="/customer" component={Customer} />
          <Route exact path="/user/:id" component={CustomerDetails} />
          <Route exact path="/product/:id" component={AddProduct} />
          <Route exact path="/product/addProduct" component={AddProduct} />
          <Route exact path="/order/:id" component={OrderDetails} />
          <Route exact path="/login" component={Login} />
          <Route path="*" component={Error}></Route>

        </Switch>
       </Router>
    
    </Fragment>
    
   
  )
}
