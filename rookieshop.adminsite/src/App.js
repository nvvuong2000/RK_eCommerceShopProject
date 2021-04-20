
import React, { Fragment, useEffect } from 'react'
import { useSelector, useDispatch, } from "react-redux";
import Orders from './component/Orders'
import Product from './component/Product'
import Customer from './component/Customer'
import CustomerDetails from './component/CustomerDetails'
import AddProduct from './component/AddProduct'
import OrderDetails from './component/OderDetails'
import Error from './component/Error';
import Login from './component/Login'
import Banner from "./component/Banner"
import PrivateRoute from './component/PrivateRoute'
import Page403 from "./component/Page403"
import Category from "./component/Category"
import Footer from "./component/Footer"
import { history } from "./index";

import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link,
  Redirect
} from "react-router-dom";
import { get_info_user} from "./actions/user"
import AddCategory from './component/AddEditCategory';

function App() {
 
  const dispatch = useDispatch();
  const { currentUser}  = useSelector((state) => state.user);
  
  
  useEffect(() => {
    dispatch(get_info_user());

  }, []);
  if (currentUser.roles == "user") {
    history.push("/page403")
  }
 
  return (

    <Fragment>


      <Router>
        <Banner user={currentUser}/>
        <Switch>
          <PrivateRoute exact path="/orders" component={Orders} />
          <Route  exact path="/products" component={Product} />         
          <Route  exact path="/category" component={Category} />
          <Route exact path="/category/addCategory" component={AddCategory} />
          <Route exact path="/category/:id" render={({ match }) => <AddCategory match={match} />} />
          <Route exact path="/orders" component={Orders} />
          <Route exact path="/orders" component={Orders} />
          <Route exact path="/customer" component={Customer} />
          <Route exact path="/user/:id" component={CustomerDetails} />
          <Route exact path="/product/:id" render={({ match}) =><AddProduct match={match} />}/>
          <Route exact path="/product/addProduct" component={AddProduct} />
          <Route exact path="/order/:id" component={OrderDetails} />
          <Route exact path="/login" component={Login} />
         <Route exact path="/page403" component={Page403}></Route>
        </Switch>
        <Footer/>
      </Router>

    </Fragment>
  );
}

export default App;
