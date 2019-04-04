import React from 'react'
import styled from 'styled-components';

const StyledButton = styled.button`
    margin: ${props => (props.margin)}px;
    width: ${props => (props.width)}px;
    height: 30px;
    border-radius: 10px;
    border: none;
    background-color: white;
    color: black;
    cursor: pointer;
    display: none;
    ${props => props.visible && 'display: block'}

`

const Button = (props) => {
  return (
      <StyledButton visible={props.visible} onClick={props.onClick} width={props.width} margintop={props.margintop}>
          <p>{props.text}</p>
      </StyledButton>
  )
}

export default Button

