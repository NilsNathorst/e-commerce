import React, {Component} from 'react'
import styled, { keyframes } from 'styled-components';
import Button from '../Button';

const StyledProduct = styled.div`
	display: flex;
	background-color: #1BE7FF;
	color: black;
	flex-direction: column;
	align-items: center;
	margin: 10 0 10 10 px;
	padding: 15px 5px 5px 5px;
	text-align: center;
	border-radius: 10px;
	p
	{
		font-style: italic;
	}

	.priceContainer{
		display: flex;
		flex: 1;
		align-items: flex-end;
	}

	img 
	{
		transition: 0.2s ease-in-out;
		height: ${props => props.height}px;
		width:  ${props => props.width}px;
		margin: 10px;
	}
	& button {
		margin: 5px 0 10px 0;
		background-color: #F9F715;
	
	}
`;

export default class Product extends Component {

	render(){
		return (
		<StyledProduct> 
			<h3>{this.props.name}</h3> 
			<img src={this.props.url} height={this.props.imgheight} width={this.props.imgwidth}></img>
			<p>{this.props.description}</p>
			<div className="priceContainer">
				<h4>{this.props.price}:-</h4>
			</div>
			<Button text="Add to cart" onClick={this.props.onClick} visible={this.props.visible} width="100"/>
		</StyledProduct>
	)
	}
}
