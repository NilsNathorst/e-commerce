import React, { Component } from 'react';
import Button from '../Button';
import styled from 'styled-components'
import { BrowserRouter as Router, Route, Link } from "react-router-dom";

const StyledDiv = styled.div`

`;

export default class Form extends Component {

    constructor(props){
        super(props)
    }

    state = {
        name: "",
        adress: "",
        zip: ""
    }

    handleChange = (e) => {
        this.setState({
            [e.currentTarget.name]: e.currentTarget.value
        })
    }

    PlaceOrder = (e) => {
        let id = localStorage.getItem('cartId')
        let formData = {}

        formData.customer = this.state
        formData.cartid = id
        formData.products = this.props.products
        
		fetch(`https://localhost:44313/api/order`, {    
            method: 'POST',
            body: JSON.stringify(formData),
			headers: {
				'Accept': 'application/json',
				'Content-Type': 'application/json'
			},
        })
        localStorage.clear('cartId')
    }
    render() {
        return (
          <StyledDiv>
              <form method="POST" class="update_product">
                      <input type="text" placeholder="name" id="name" name="name" value={this.state.name} onChange={this.handleChange}/>
                      <input type="text" placeholder="adress" id="description" name="adress" value={this.state.adress} onChange={this.handleChange}/>
                      <input type="text" placeholder="zip" id="quantity" name="zip" value={this.state.zip} onChange={this.handleChange}/>
                      <Link to="/" style={{textDecoration: 'none', color: 'inherit'}}>
                      <Button text="Place Order" class="form_button" type="submit" name="update" onClick={this.PlaceOrder} visible width="100">
                      </Button>
                      </Link>
              </form>
          </StyledDiv>
        )
    }
}
