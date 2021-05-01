
import React, { Fragment, useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import {Route, Router,Switch} from "react-router-dom";
import { ToastContainer } from "react-toastify";
import { get_info_user } from "./actions/user";
import AddCategory from './component/AddEditCategory';
import AddProduct from './component/AddEditProduct';
import Banner from "./component/Banner";
import Category from "./component/Category";
import Customer from './component/Customer';
import CustomerDetails from './component/CustomerDetails';
import Footer from "./component/Footer";
import Login from './component/Login';
import OrderDetails from './component/OderDetails';
import Orders from './component/Orders';
import Product from './component/Product';
import history from './history';

function App() {
  
  const dispatch = useDispatch();
  const { currentUser}  = useSelector((state) => state.user);
  const { isLoginSuccess } = useSelector((state) => state.user);
  
  
  useEffect(() => {
    if (isLoginSuccess===true){
      dispatch(get_info_user());
    }
  }, [isLoginSuccess]);

 
  return (

    <Fragment>


      <Router history={history}>
        <Banner user={currentUser}/>
        <Switch>
          <Route exact path="/orders" component={Orders} />
          <Route  exact path="/products" component={Product} />         
          <Route  exact path="/category" component={Category} />
          <Route exact path="/category/addCategory" component={AddCategory} />
          <Route exact path="/category/:id" render={({ match }) => <AddCategory match={match} />} />
          <Route exact path="/orders" component={Orders} />
          <Route exact path="/customer" component={Customer} />
          <Route exact path="/customer/:id" render={({ match }) => <CustomerDetails match={match} />} />
          {/* <Route exact path="/product/:id" render={({ match}) =><AddProduct match={match} />}/> */}
          <Route exact path={["/product/addProduct", "/product/:id"]} render={({ match }) => <AddProduct match={match} />} />
          <Route exact path="/order/:id" render={({ match }) => <OrderDetails match={match} />} />
          <Route exact path="/login" component={Login} />
        </Switch>
        <Footer/>
      </Router>
      <ToastContainer />
    </Fragment>
  );
}

export default App;
