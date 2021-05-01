import React, { useState, Fragment, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Redirect } from "react-router";
import { get_info_user, login } from "../actions/user";
import { useHistory } from "react-router-dom";
import { Formik, useFormik } from "formik";
import * as Yup from "yup";
export default function Login() {

  const dispatch = useDispatch();
  
  const { currentUser } = useSelector((state) => state.user);

  let history = useHistory();
  
  if (currentUser) {

    if (currentUser.roles == "admin") {

      history.push('/')
    }


  }


  
  const [data, setData] = useState({
  
    email: "",
  
    password: "",
  });
  function handleChange(evt) {
   
    const value = evt.target.value;
   
    setData({
   
      ...data,
   
      [evt.target.name]: value
   
    });
  }
  const formik = useFormik({
    //When set to true, the form will reinitialize every time the initialValues prop changes. 
    enableReinitialize: true,
    
    initialValues: {
     
      email: data.email,
     
      password: data.password,
    },
   
    validationSchema: Yup.object({
   
      email: Yup.string().email(),
   
      password: Yup.string().required().min(8),
    }),
   
    onSubmit: () => {
     
      dispatch(login(data))
    }
  });


  return (


    <main id="content" role="main" className="main">
      {/* Content */}
      <div className="container py-5 py-sm-7">
        <a className="d-flex justify-content-center mb-5" href="index.html">
          <img className="z-index-2" src="https://upload.wikimedia.org/wikipedia/commons/1/14/Logo_Vavu.png" alt="Image Description" style={{ width: '8rem' }} />
        </a>
        <div className="row justify-content-center">
          <div className="col-md-7 col-lg-5">
            {/* Card */}
            <div className="card card-lg mb-5">
              <div className="card-body">
                {/* Form */}
                <Formik>
                  <form className="js-validate" onSubmit={formik.handleSubmit}>
                  <div className="text-center">
                    <div className="mb-5">
                      <h1 className="display-4">Sign in</h1>
                    </div>
                  </div>
                  {/* Form Group */}
                  <div className="js-form-message form-group">
                    <label className="input-label" htmlFor="signinSrEmail">Your email</label>
                    <input type="text" value={formik.values.email} onChange={handleChange} className="form-control form-control-lg" name="email" placeholder="ex: example@gmail.com" />
                    {formik.errors.email &&
                      formik.touched.email && (
                      <p style={{ color: "red" }}>{formik.errors.email}</p>
                      )}
                  </div>
                  {/* End Form Group */}
                  {/* Form Group */}
                  <div className="js-form-message form-group">
                      <label className="input-label" htmlFor="signinSrEmail">Your Password</label>
                    <div className="input-group input-group-merge">
                      <input type="password" value={formik.values.password} onChange={handleChange} className="js-toggle-password form-control form-control-lg" name="password" id="signupSrPassword" placeholder="8+ characters required" aria-label="8+ characters required" required data-msg="Your password is invalid. Please try again." />
                   
                        
                    </div>
                      {formik.errors.password &&
                        formik.touched.password && (
                          <p style={{ color: "red" }}>{formik.errors.password}</p>
                        )}
                  </div>
                  {/* End Form Group */}
                  <button type="submit" className="btn btn-lg btn-block btn-primary">Sign in</button>
                </form>
                </Formik>
                {/* End Form */}
              </div>
            </div>
            {/* End Card */}
          </div>
        </div>
      </div>
      {/* End Content */}
    </main>



  )
}
