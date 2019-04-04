import styled from 'styled-components';
import React,{Component} from 'react'
import { BrowserRouter as Router, Route, Link } from "react-router-dom";
import Product from '../Product/'

const StyledWrapper = styled.div`
	position: absolute;
	left: 20vw;
	top: 25vh;
    width: 100%;
    display: grid;
    grid-template-columns: repeat(5, minmax(80px, 1fr));
    grid-template-rows: repeat(autofit minmax(80px, 1fr));
    grid-auto-flow: dense;
	grid-gap: 1em;

	.addToCart {
		display: ${props => props.toggleanim ? "block" : 'none'};
		position: absolute;
		color: #EE4266;
		z-index: 3;
		font-size: 40px;
		left: 12vw;
		top: 5vh;
	}
`;

class Wrapper extends Component {
	state = {
		items: [],
		toggleanim: false
	}

	componentDidMount() {
		this.fetchProduct()
	}
	
	fetchProduct = () => {
		const url = 'https://localhost:44313/api/product'
		
		return fetch(url)
		.then(response => response.json())
		.then(data => {
			data.map(item => {
				this.setState({
					items: [ ...this.state.items, item]
					
				})
			})
		})
	}
	postProduct = (item) => {
		
		const body = {
			productId: item.id,
			quantity: 1
		}

		if (localStorage.getItem('cartId')) {
			body.cartId = localStorage.getItem('cartId')
		}

		fetch('https://localhost:44313/api/cart', {
			method: 'POST',
			headers: {
				'Accept': 'application/json',
				'Content-Type': 'application/json',
			},
			body: JSON.stringify(body)
})
.then(response => response.json())
.then(response => {
	localStorage.setItem('cartId', response.id)
})

	}
	
	handleClick = (props) => {
		
		this.postProduct(props)
		this.setState({
			toggleanim: !this.state.toggleanim
		})
		setTimeout(() => {
			this.setState({
				toggleanim: !this.state.toggleanim
			})
		}, 600);
	}

	render(){
		return (
			<StyledWrapper toggleanim={this.state.toggleanim}>
				<div className="addToCart">
				<h1>ADDED TO CART</h1>
				</div>
				{this.state.items.map(item => {
					return(
					<Product 
					name={item.product_name} 
					description={item.product_description} 
					url={item.product_image} 
					price={item.product_price} 
					id={item.Id}
					visible={true}
					onClick={() => this.handleClick(item)}
					imgwidth="130"
					imgheight="130"
					/>
					)
				})}
			</StyledWrapper>
		)
	}
}

export default Wrapper
