import React from 'react'

export default function ImagesProduct(props) {

    let imageList = props.list

    return (
        <div className="card-body">
            {/* Gallery */}
            <div id="fancyboxGallery" className="js-fancybox row justify-content-sm-center gx-2">
                {imageList && imageList.map((item,index) => {
                    return(
                        <div className="col-6 col-sm-4 col-md-3 mb-3 mb-lg-5" key={index}>

                            {/* Card */}
                            <div className="card card-sm">
                                <img className="card-img-top" src={item} alt="Image Description" />
                                <div className="card-body">
                                    <div className="row text-center">
                                        <div className="col">
                                            <label className="toggle-switch toggle-switch-sm" htmlFor="stocksCheckbox1">
                                                <input type="radio" className="toggle-switch-input" id="stocksCheckbox1" name="status" checked={index==0} />
                                                <span className="toggle-switch-label">
                                                    <span className="toggle-switch-indicator" />
                                                </span>
                                            </label>
                                        </div>
                                        <div className="col column-divider">
                                           Default
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    );
                })}
            </div>
        </div>
    )
}
