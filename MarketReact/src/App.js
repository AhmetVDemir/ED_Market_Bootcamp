import './App.css';
import Airplanes from './Compenents/Airplanes';
import Categories from './Compenents/Categories';
import Nav from './Compenents/Nav';
import {useState,useEffect} from "react"
import AirplaneAdd from './Compenents/AirplaneAdd';


function App() {

  //Kategori değiştirme olayını kontrol etmmek için
  const [SecilenKategori,setSecilenKategori] = useState(0);

  //Çekilecek airplane ürünlerini tutmak için
  const [airplanes, setAirplanes] = useState([])


  useEffect(() => {
    
    //Airplane verilerini çekmek için kullanılan fonksiyon
    veriCek(SecilenKategori)


  },[SecilenKategori] )

  //Veri çekicek olan fonksiyon
  const veriCek = (kategoriId) =>
  {
    if(kategoriId === 0){
      fetch('https://localhost:44358/api/Airplanes/getall')
            .then(response => response.json())
            .then(res => setAirplanes(res.data))
    }else {
      fetch('https://localhost:44358/api/Airplanes/getbycategory?categoryId='+kategoriId)
      .then(response => response.json())
      .then(res => setAirplanes(res.data))
    }
    

  }


  return (
    <div className="App">

      <div className="container">
        <Nav />
        <div className="row">
          <div className="col-md-3">
            <Categories Cat={SecilenKategori} sCat={setSecilenKategori} />
          </div>
          <div className="col-md-9">
            <Airplanes airplanes={airplanes} />
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
