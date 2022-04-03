import React, { useEffect, useState } from 'react'

const Categories = (props) => {

    const [kategoriler, setKategoriler] = useState([])

    useEffect(() => {
        fetch('https://localhost:44358/api/Categories/getall')
            .then(response => response.json())
            .then(res => setKategoriler(res.data))

    }, [])

    return (
        <div>
            <ul className="list-group">
                <li className="list-group-item" onClick={()=>{props.sCat(0)}}>Tüm Kategoriler</li>
                {kategoriler.map((cat) => (
                    <li key={cat.categoryId} className="list-group-item" onClick={()=>{
                        props.sCat(cat.categoryId)
                    }} >{cat.categoryName}</li>
                ))}

            </ul>


        </div>
    )
}

export default Categories
