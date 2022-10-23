function SearchBar() {
    
    return  (
        <div class="w-50 mx-auto input-group gap-3">
            <input type="text" class="form-control"/>
            <div class="input-group-append">
                <button class="btn btn-primary" type="button">Search</button>
            </div>
        </div>
    )
}

export default SearchBar;