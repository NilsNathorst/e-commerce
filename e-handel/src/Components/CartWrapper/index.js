import styled from 'styled-components';
import React,{Component} from 'react'
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import Product from '../Product/'
import Button from '../Button';

const StyledDiv = styled.div`
    width: 100%;
    margin-top: 20px;
    display: grid;
    grid-template-columns: repeat(5, minmax(80px, 1fr));
    grid-template-rows: repeat(autofit minmax(80px, 1fr));
    grid-auto-flow: dense;
    grid-gap: 1em;

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
	
	emptyCart = () => {
		let id = localStorage.getItem('cartId')
		fetch(`https://localhost:44313/api/cart/${id}`, {    
			method: 'DELETE',
			headers: {
				'Accept': 'application/json',
				'Content-Type': 'application/json'
			},
		})
		this.setState({
			items: []
		})
	}
	render(){
		console.log(this.state.items)
		return (
            <div>
			<StyledDiv>
				{this.state.items.map(item => {
					return(
					<Product 
					name={item.product_name} 
					description={item.product_description} 
					url={item.product_image} 
					price={item.product_price} 
					id={item.Id}
					imgwidth="100"
					imgheight="100"
					/>
					)
                })}
			</StyledDiv>
            <Link to="/Order" style={{textDecoration: 'none', color: 'inherit'}}>
            <Button visible width="200" margin="20" text="Place Order" onClick={this.handleClick}/>
            </Link>
            <Button visible width="200" margin="20" text="Empty Cart" onClick={this.emptyCart}/>
            </div>
		)
	}
}

export default Wrapper
