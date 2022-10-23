import { useEffect, useState } from "react";

function ContractsTableRow(props) {
    const [contract, setContract] = useState();

    useEffect(() => {
        setContract(props.contract);
    }, [props.contract])

    const formatDate = (date) => {
        return date.slice(0, 10);
    }

    return  (
        contract &&
        <tr>
            <td><button type="button" className="btn btn-link" onClick={() => props.togglePopup(contract.id)}>{contract.contractNumber}</button></td>
            <td>{contract.certificateNumber}</td>
            <td>{contract.clientName}</td>
            <td>{formatDate(contract.startDate)}</td>
            <td>{formatDate(contract.endDate)}</td>
        </tr>
    )
}

export default ContractsTableRow;