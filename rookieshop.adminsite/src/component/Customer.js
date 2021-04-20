import React,{useEffect} from 'react'
import CustomerList from "./CustomerList";
import {get_list_user} from "../actions/user"
import { useSelector, useDispatch, } from "react-redux";
export default function Customer() {
    const dispatch = useDispatch();
    useEffect(() => {
        dispatch(get_list_user());
      
    }, []);
    const users = useSelector((state) => state.user.listUsers);
    return (
        <div>
            {/* Content */}
            <div className="content container-fluid">
                {/* Page Header */}
                <div className="page-header">
                    <div className="row align-items-center mb-3">
                        <div className="col-sm mb-2 mb-sm-0">
                            <h1 className="page-header-title">Customer <span className="badge badge-soft-dark ml-2" /></h1>
                        </div>
                    </div>
                    {/* End Row */}

                </div>

                {/* Card */}
                <div className="card">

              
                 <CustomerList list ={users}/>
                </div>
                {/* End Content */}
            </div>

        </div>
    )
}
