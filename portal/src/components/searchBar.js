import { useState } from "react";

function SearchBar(props) {
    const [keyword, setKeyword] = useState(null);
    return  (
        <div className="w-50 mx-auto input-group gap-3">
            <input onChange={(e) => setKeyword(e.target?.value)} type="text" className="form-control"/>
            <div className="input-group-append">
                <button onClick={() => props.Search(keyword)} className="btn btn-primary" type="button">Search</button>
            </div>
        </div>
    )
}

export default SearchBar;