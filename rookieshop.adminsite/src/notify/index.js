import { toast, Zoom } from "react-toastify";

export const error = (msg) => {
    toast.error(msg, {
        position: "top-right",
        autoClose: 3800,
        hideProgressBar: true,
        closeOnClick: false,
        pauseOnHover: false,
        draggable: false,
        transition: Zoom,
    });
};

export const success = (msg) => {
    toast.success(msg, {
        position: "top-right",
        autoClose: 3800,
        hideProgressBar: true,
        closeOnClick: false,
        pauseOnHover: false,
        draggable: false,
        transition: Zoom,
    });
};

export const warning = (msg) => {
    toast.warning(msg, {
        position: "top-right",
        autoClose: 3800,
        hideProgressBar: true,
        closeOnClick: false,
        pauseOnHover: false,
        draggable: false,
        transition: Zoom,
    });
};
