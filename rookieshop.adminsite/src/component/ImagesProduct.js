import React from 'react'

export default function ImagesProduct(props) {
    let imageList = props.list
    console.log(imageList);

    return (
        <div className="card-body">
            {/* Gallery */}
            <div id="fancyboxGallery" className="js-fancybox row justify-content-sm-center gx-2" data-hs-fancybox-options="{
                 &quot;selector&quot;: &quot;#fancyboxGallery .js-fancybox-item&quot;
               }">
                {imageList && imageList.map((item,index) => {
                    return(
                        <div className="col-6 col-sm-4 col-md-3 mb-3 mb-lg-5">

                            {/* Card */}
                            <div className="card card-sm">
                                <img className="card-img-top" src={item} alt="Image Description" />
                                <div className="card-body">
                                    <div className="row text-center">
                                        <div className="col">
                                            <label className="toggle-switch toggle-switch-sm" htmlFor="stocksCheckbox1">
                                                <input type="radio" className="toggle-switch-input" id="stocksCheckbox1" name="status" {...item.status == true ? "defaultChecked" : ""} />
                                                <span className="toggle-switch-label">
                                                    <span className="toggle-switch-indicator" />
                                                </span>
                                            </label>
                                        </div>
                                        <div className="col column-divider">
                                            <a className="text-danger" href="javascript:;" data-toggle="tooltip" data-placement="top" title data-original-title="Delete">
                                                <i class="fas fa-trash-alt"></i>
                                            </a>
                                        </div>
                                    </div>
                                    {/* End Row */}
                                </div>
                            </div>
                            {/* End Card */}
                        </div>
                    );
                })}
            </div>
        </div>
    )
}
