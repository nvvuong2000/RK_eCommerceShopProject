
import React, { useState, Fragment } from "react";
import { useDispatch, useSelector } from "react-redux";
// import { login, get_info_user } from "./actions/user";
import Login from "./component/Login"
import Index from "./component/Index"

function App() {
  // const dispatch = useDispatch();
  // const [data, setData] = useState({
  //   tenDangNhap: "",
  //   matKhau: "",
  // });
  // var __token = localStorage.getItem("__token");
  // if(__token){
  //   dispatch(get_info_user());
  // }
  
  // const handleSubmit = (e) => {
  //    e.preventDefault();   
  //   dispatch(login(data))
  // };
  return (

    <Fragment>
     
      <Index/>
      {/* <form onSubmit={handleSubmit}>
        <input name="email" type="email" value={data.tenDangNhap} onChange={(e) => setData({ ...data, tenDangNhap: e.target.value })} />
        <input name="password" value={data.matKhau} onChange={(e) => setData({ ...data, matKhau: e.target.value })} type="password" />
        <button type="submit" >Đăng nhập</button>
      </form> */}
    </Fragment>
  );
}

export default App;
