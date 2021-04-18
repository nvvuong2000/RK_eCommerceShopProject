import React from "react";
import { Route, Redirect, useHistory } from "react-router-dom";


import { useSelector } from 'react-redux';
import Login from "./Login";

const PrivateRoute = ({ role, component, ...rest }) => {
    const Component = component;

    const { currentUser } = useSelector((state) => state.user);

    if (currentUser.roles=="admin")
    {
        return <Route {...rest} render={(props) => <Component {...props} />} />;

    }
    else
    {
       return <Redirect to="/login"/>
    }
};

export default PrivateRoute;
