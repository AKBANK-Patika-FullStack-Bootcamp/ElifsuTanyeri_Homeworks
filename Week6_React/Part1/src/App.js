import dogs from "./Components/Dog";
import CleanDog, {hour} from "./Components/DogCareUtility";
import  MyCard from "./Components/CardTemplate";

function App() {

  const {name, height, weight}= dogs;
  const careHour = hour * weight;

  return(    
  <>
    {console.log(`Köpek Adı: ${name}`)}
    {console.log(`Köpek Boyu: ${height}`)}
    {CleanDog()} 
    {console.log(`Köpek İlgi Saati: ${careHour}`)}
  <MyCard />
  </>
  )
}

export default App;

