import React, { useEffect, useState } from "react";
 
function ContractDetailPopUp (props) {
    const formatDate = (date) => {
        return date.slice(0, 10);
    }

    const formatter = new Intl.NumberFormat('vi-VN', {
        style: 'currency',
        currency: 'VND',
    });

    const [TNDSBB, setTNDSBB] = useState(null);
    const [TNDSTN, setTNDSTN] = useState(null);
    const [LPX, setLPX] = useState(null);
    const [VCX, setVCX] = useState(null);

    useEffect(() => {
        const TNDSBBValue = props.contract?.ContractsCovers?.find(x => x.CoverName === "166")?.CoverValue;
        if (TNDSBBValue != null){
            setTNDSBB(formatter.format(TNDSBBValue));
        }
        const TNDSTNValue = props.contract?.ContractsCovers?.find(x => x.CoverName === "167")?.CoverValue;
        if (TNDSTNValue != null){
            setTNDSTN(formatter.format(TNDSTNValue));
        }
        const LPXValue = props.contract?.ContractsCovers?.find(x => x.CoverName === "168")?.CoverValue;
        if (LPXValue != null){
            setLPX(formatter.format(LPXValue));
        }
        const VCXValue = props.contract?.ContractsCovers?.find(x => x.CoverName === "169")?.CoverValue;
        if (VCXValue != null){
            setVCX(formatter.format(VCXValue));
        } 
    }, []);

    return (
        <div className="popup-box">
            <div className="box">
                <span className="close-icon" onClick={() => props.handleClose(null)}>x</span>
                <div>
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Số hợp đồng bảo hiểm</th>
                                <th>Số giấy chứng nhận bảo hiểm</th>
                                <th>Ngày bắt đầu</th>
                                <th>Ngày kết thúc</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>{props.contract?.ContractNumber}</td>
                                <td>{props.contract?.CertificateNumber}</td>
                                <td>{formatDate(props.contract?.StartDate)}</td>
                                <td>{formatDate(props.contract?.EndDate)}</td>
                            </tr>
                        </tbody>
                    </table>
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Tên khách hàng</th>
                                <th>Số điện thoại</th>
                                <th>Địa chỉ email</th>
                                <th>Địa chỉ khác hàng</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>{props.contract?.ClientName}</td>
                                <td>{props.contract?.ClientPhoneNumber}</td>
                                <td>{props.contract?.ClientEmail}</td>
                                <td>{props.contract?.ClientAddress}</td>
                            </tr>
                        </tbody>
                    </table>
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Hãng xe</th>
                                <th>Mẫu xe</th>
                                <th>Năm sản xuất</th>
                                <th>Biển số</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>{props.contract?.CarBrandText}</td>
                                <td>{props.contract?.CarModelText}</td>
                                <td>{props.contract?.CarProductionYear}</td>
                                <td>{props.contract?.CarLicensePlate}</td>
                            </tr>
                        </tbody>
                    </table>
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Bảo hiểm TNDS bắt buộc</th>
                                <th>Bảo hiểm TNDS tự nguyện</th>
                                <th>Bảo hiểm lái phụ xe ô tô</th>
                                <th>Bảo hiểm vật chất xe</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>{TNDSBB}</td>
                                <td>{TNDSTN}</td>
                                <td>{LPX}</td>
                                <td>{VCX}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
};
 
export default ContractDetailPopUp;