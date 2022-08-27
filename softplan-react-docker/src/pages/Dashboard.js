import Sala from "../components/Salas/Sala";

import { useEffect, useState } from "react";

import * as React from 'react';
import { styled } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Paper from '@mui/material/Paper';
import Grid from '@mui/material/Grid';

import { buscaSalasService } from '../services/requestService/salas/salas';

    const Item = styled(Paper)(({ theme }) => ({
        backgroundColor: theme.palette.mode === 'dark' ? '#1A2027' : '#fff',
        ...theme.typography.body2,
        padding: theme.spacing(1),
        textAlign: 'center',
        color: theme.palette.text.secondary,
        borderRadius: "5px",
        boxShadow: "1px 1px 1px 1px rgba(0, 0, 0, 0.9)",
    }));

    const Dashboard = () => {

    const [data, setData] = useState([]);

    useEffect(() => {
        async function getSalas() {
          const salas = await buscaSalasService();
          if(salas)setData(salas.data);
        }
        getSalas();
        
    }, []);

    return (
        <Box sx={{ width: '100%', height: '100vh', background: '#199999', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
            <Box>
                <Box sx={{ flexGrow: 1, width: 500, height: 400}}>
                    <Grid container spacing={2}>
                        <Grid item xs={12} >
                        <Item><Sala data={data[0]} /></Item>
                        </Grid>
                        <Grid item xs={6}>
                        <Item><Sala data={data[2]} /></Item>
                        </Grid>
                        <Grid item xs={6}>
                        <Item><Sala data={data[3]} /></Item>
                        </Grid>
                        <Grid item xs={12}>
                        <Item><Sala data={data[1]}/></Item>
                        </Grid>
                    </Grid>
                </Box>
            </Box>
        </Box>
        
    );
}

export default Dashboard;