import { useEffect, useState } from "react";
import ContractsTableRows from "./contractsTableRow";

function ContractsTable(props) {
    const [contracts, setContracts] = useState();
    useEffect(() => {
        setContracts(props.contracts);
    }, [props.contracts])

    return  (
        <div className="pt-5">
            <table className="table">
                <thead>
                    <tr>
                        <th>Số hợp đồng bảo hiểm</th>
                        <th>Số giấy chứng nhận bảo hiểm</th>
                        <th>Tên khách hàng</th>
                        <th>Ngày bắt đầu</th>
                        <th>Ngày kết thúc</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        contracts &&
                        contracts.map((contract, index) => 
                            <ContractsTableRows contract={contract} togglePopup={props.togglePopup} key={index} />
                        )
                    }
                </tbody>
            </table>
        </div>
    )
}

export default ContractsTable;