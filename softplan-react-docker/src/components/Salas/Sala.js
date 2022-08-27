import { Badge, CardContent } from "@mui/material";
import Card from '@mui/material/Card';
import * as React from 'react';
import Typography from '@mui/material/Typography';
import FormDialog from '../Forms/RegisterForm/FormDialog'
import { useEffect, useState } from "react";

const Sala = (props) => {
  
  //const color = props.data?.nome === 'Aliança' ? 'lightblue' : 'lightgray';

  const [open, setOpen] = useState(false);

  return(
    <>
      <Card 
        sx={{
          borderRadius: "5px",
          boxShadow: "1px 1px 1px 1px rgba(0, 0, 0, 0.5)",
          padding: '0px',
          cursor: 'pointer',
          background: "#D9D9D9",
        }}

        onClick={() => {
          setOpen(true)
        }}
      >
        <Badge
          sx={{
            borderTop:20
          }}
          color={props.data?.disponivel ? 'success' : 'error'} 
          overlap="circular"
          badgeContent={props.data?.disponivel ? 'Disponível' : 'Indisponível'}  
        />
          <CardContent
            sx={{
              display: 'flex',
              flexDirection: 'column',
              alignItems: 'center',
              "&:last-child": {
                paddingBottom: 3,
                paddingTop: 3
              }
            }}
          >
          <Typography fontSize={30}>{props.data?.nome}</Typography>
          </CardContent>
      </Card>
      <FormDialog data={props.data} open={open} setOpen={setOpen}/>
    </>
  )
}

export default Sala;