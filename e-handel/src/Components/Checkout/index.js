import styled from 'styled-components';
import React,{Component} from 'react'
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import Product from '../Product/'
import Button from '../Button';
import Form from '../PostForm';

const StyledDiv = styled.div`
    width: 100%;
    margin-top: 20px;
    margin-left: 20px;
    p {
        position: relative;
        left: 100px;
    }
    span {
        color: red;
    }
`;

class Wrapper extends Component {
	state = {
		items: []
	}

	componentDidMount() {
		this.fetchProduct()
    }
    
	fetchProduct = () => {

        var id = 2020

        if(localStorage.getItem('cartId'))
        {
            id = localStorage.getItem('cartId')
        }
		const url = `https://localhost:44313/api/cart/${id}`
		return fetch(url)
		.then(response => response.json())
		.then(data => {
			data.products.map(item => {
                console.log(item)
                console.log(url)
				this.setState({
					items: [ ...this.state.items, item]
				})
			})
		})
    }
    
	render(){
        const products = [...this.state.items.map(item => {
            return item.id
        })]
        console.log(this.state.items)
        let total = 0
		return (
            <div>
			<StyledDiv>
                <h1>YOUR ORDER:</h1>
                <ul>
                {this.state.items.map(item => {
                    total += item.product_price
					return(
					<img src={item.product_image} alt="" height="100" width="100"/>
					)
                })}
                </ul>
                <h1>TOTAL COST: <span>{total}:-</span></h1>
			</StyledDiv>
            <Form products={products}/>
            </div>
		)
	}
}

export default Wrapper
