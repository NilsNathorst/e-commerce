import styled from 'styled-components';
import React from 'react'
import { BrowserRouter as Router, Route, Link } from "react-router-dom";

const StyledNav = styled.div`
	position: relative;
	display: flex;
	justify-content: space-evenly;
	align-items: center;
	background: inherit;
	color: black;
	width: 100%;
	height: 12vh;
	top: 0;
	.fas
	{
		font-size: 28px;
	}
`;
const Nav = () => {
	return (
		<StyledNav>
				<div>
					<Link to="/" style={{textDecoration: 'none', color: 'inherit'}}>
						<h1>Home</h1>
					</Link>
				</div>
				<div>
					<Link to="/Products" style={{textDecoration: 'none', color: 'inherit'}}>
						<h1>Products</h1>
					</Link>
				</div>
				<div>
					<Link to="/Cart" style={{textDecoration: 'none', color: 'inherit'}}>
						<i className="fas fa-shopping-cart"></i>
					</Link>
				</div>
			</StyledNav>
	)
}

export default Nav

