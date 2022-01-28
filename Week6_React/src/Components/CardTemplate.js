import {Card, ListGroup } from "react-bootstrap";
import dogs from "./Dog";
import Tiera from "../Assets/Tiera.jpeg";
import "../App.css";
import hour from "./DogCareUtility"

const MyCard = () =>{
  const {id, name, height, weight, owner}= dogs;
    return(
    <>
    <Card style={{ width: '28rem' }}>
        <Card.Body>
         <Card.Title>ID NUMBER: {id}</Card.Title>
          <img className= "deneme"src={Tiera} alt="TieraPhoto"/>
            <Card.Subtitle className="subt">Dog Name: {name} </Card.Subtitle>
            <ListGroup variant="flush">
            <ListGroup.Item>Dog Owner: {owner} </ListGroup.Item>
            <ListGroup.Item>Dog Height: {height}</ListGroup.Item>
            <ListGroup.Item>Dog Weight: {weight}</ListGroup.Item>
            <ListGroup.Item>Hours Needed for Dog Care: {hour}</ListGroup.Item>
          </ListGroup>
      <Card.Link className="btn" href="#">Details</Card.Link>
    </Card.Body>
    </Card>
    </>
    )
}

export default MyCard;