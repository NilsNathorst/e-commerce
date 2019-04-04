import styled from 'styled-components';
import React from 'react'
const StyledFooter = styled.div`
	color: #EECF6D;
	position: fixed;
	width: 100%;
	margin-top: 100px;
	height: 10vh;
	bottom: 0;
`;
const Footer = () => {
	return (
<StyledFooter>
	<p>contact</p>
	<p>complaints</p>
</StyledFooter>
	)
}

export default Footer
