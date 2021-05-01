import React, { Fragment, useEffect, useState } from 'react'
import { useSelector, useDispatch, } from "react-redux";


export default function CustomerInfo(props) {
    
    const info = props.info;
   
    const [userInfo,setInfo]= useState({
        userName: "",
       
        userTel:"",
       
        userAddress:"",
    });
    useEffect(()=>{
        if (info && info[0]) {
            setInfo({
               
                userName: info[0].userName,
               
                userAddress: info[0].userAddress,
               
                userTel: info[0].userTel,
            })
        }
    }, [info])
    
    return (
        <Fragment>
            {userInfo &&
             <div className="col-lg-4">
                <div id="accountSidebarNav" style={{}} />
            
                <div className="js-sticky-block card mb-3 mb-lg-5">
                
                    <div className="card-header">
                        <h5 className="card-header-title">Profile</h5>
                    </div>
                  
                    <div className="card-body">
                        <ul className="list-unstyled list-unstyled-py-3 text-dark mb-3">
                            <li className="py-0">
                                <small className="card-subtitle">About</small>
                            </li>
                            <li>
                                <i className="fas fa-user" />  {userInfo.userName}
                            </li>
                           
                            <li className="pt-2 pb-0">
                                <small className="card-subtitle">Contacts</small>
                            </li>
                           
                            <li>
                                <i className="fas fa-phone"/> {userInfo.userTel}
                            </li>
                            
                            <li>
                                <i className="fas fa-home"/> {userInfo.userAddress}
                            </li>
                        
                        </ul>
                    
                    </div>
                  
                </div>
        
            </div>
        
            }
           
        </Fragment>
    )
}
