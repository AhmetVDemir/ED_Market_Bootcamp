import React from 'react'

const AirplaneAdd = () => {
    return (
        <div>
            <h1>Uçak Ekle</h1>
            <div class="content">
    <div class="col-md-12">
        <div class="card">
            <div class="card-header">
                <h5 class="title">Uçak Ekle</h5>
            </div>
            <div class="card-body">
                <form >
                    <div class="mb-3">
                        <div class="form-group">
                            <label for="airplaneName">Ürün Adı</label>
                            <input type="text" id="airplaneName" formControlName="airplaneName" class="form-control"
                                placeholder="Uçak Adi" />
                        </div>
                    </div>

                    <div class="mb-3">
                        <div class="form-group">
                            <label for="categoryId">Kategori Id</label>
                            <input type="number" id="categoryId" formControlName="categoryId" class="form-control"
                                placeholder="Katagori Id si" />
                        </div>
                    </div>
                    <div class="mb-3">
                        <div class="form-group">
                            <label for="unitsInStock">Stok Adedi</label>
                            <input type="number" id="unitsInStock" formControlName="unitsInStock" class="form-control"
                                placeholder="Stok Adedi" />
                        </div>
                    </div>
                    <div class="mb-3">
                        <div class="form-group">
                            <label for="unitPrice">Birim Fiyatı</label>
                            <input type="number" id="unitPrice" formControlName="unitPrice" class="form-control"
                                placeholder="Birim Fiyatı" />
                        </div>
                    </div>


                </form>
            </div>
            <div class="card-footer">
                <button class="btn btn-fill btn-success" >Ekle</button>
            </div>
        </div>

    </div>
</div>
            
        </div>
    )
}

export default AirplaneAdd
