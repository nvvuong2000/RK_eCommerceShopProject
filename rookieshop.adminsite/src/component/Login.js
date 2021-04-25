import React, { useState, Fragment, useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { Redirect } from "react-router";
import { get_info_user, login } from "../actions/user";
import { useHistory } from "react-router-dom";
import { Formik, useFormik } from "formik";
import * as Yup from "yup";
export default function Login() {
  const { currentUser } = useSelector((state) => state.user);
  const [isAuthencation, setisAuthencation] = useState(false);
  let history = useHistory();
  if (currentUser) {
    console.log(currentUser);
    if (currentUser.roles == "user") {
      history.push("/page403")
    }
    if (currentUser.roles == "admin") {

      history.push('/')
    }


  }

  const dispatch = useDispatch();
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
      <div className="position-fixed top-0 right-0 left-0 bg-img-hero" style={{ height: '32rem', backgroundImage: 'url(assets/images/abstract-bg-4.svg)' }}>
        {/* SVG Bottom Shape */}
        <figure className="position-absolute right-0 bottom-0 left-0">
          <svg preserveAspectRatio="none" xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" viewBox="0 0 1921 273">
            <polygon fill="#fff" points="0,273 1921,273 1921,0 " />
          </svg>
        </figure>
        {/* End SVG Bottom Shape */}
      </div>
      {/* Content */}
      <div className="container py-5 py-sm-7">
        <a className="d-flex justify-content-center mb-5" href="index.html">
          <img className="z-index-2" src="/public/asset/svg/logo.svg" alt="Image Description" style={{ width: '8rem' }} />
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
                      <p>Don't have an account yet? <a href="#">Sign up here</a></p>
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
