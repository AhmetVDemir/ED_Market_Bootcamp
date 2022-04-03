import React, { useEffect, useState } from 'react'
import alertify from 'alertifyjs';

const Airplanes = (props) => {


    const [filterAir,setFilterAir] = useState(props.airplanes)


    useEffect(() => {

        filtrele(filterAir)
       
    }, [filterAir])

    const filtrele = (filtre) => {
        if(filtre == ""){
                setFilterAir(props.airplanes)
        }else{
                console.log(filterAir.toString())
        }

    }

    return (
        
        <div>

<div class="mb-3">
                <label for="filterText" className="form-label">Ürün Ara</label>
                <input type="text" onChange={(e)=>{
                    setFilterAir(e.target.value.toLowerCase())
                    alertify.success(filterAir)

                }} className="form-control" id="filterText" placeholder="Arama ifadesi girin" />
            </div>


            <table className="table border-danger table-striped table-bordered">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Kategori</th>
                        <th>İsim</th>
                        <th>Marka</th>
                        <th>Model</th>
                        <th>Stok Adedi</th>
                        <th>Birim Fiyatı</th>
                        <th></th>
                    </tr>

                </thead>
                <tbody>
                    {props.airplanes.map((air) => (
                        <tr key={air.airplaneId}>
                            <td> {air.airplaneId} </td>
                            <td> {air.categoryId} </td>
                            <td> {air.airplaneName}</td>
                            <td> {air.airplaneBrand}</td>
                            <td> {air.airplaneModel}</td>
                            <td> {air.unitsInStock}</td>
                            <td> {air.unitPrice}</td>
                            <td>
                                <button onClick={()=>{alertify.success('Ok')}} className="btn btn-success">Sepete Ekle</button>
                            </td>
                        </tr>

                    ))}

                </tbody>

            </table >


        </div >
    )
}

export default Airplanes
