import * as React from 'react';
import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogTitle from '@mui/material/DialogTitle';
import { Typography } from '@mui/material';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import { useEffect, useState } from 'react';
import { insereReservaService } from '../../../services/requestService/salas/salas';


export default function FormDialog({open, data, setOpen}) {
    
    const [email, setEmail] = useState('');
    const [dataInicio, setDataInicio] = useState('');
    const [dataFim, setDataFim] = useState('');
    const [sala, setSala] = useState(data?.nome);
    const [reserva, setReserva] = useState({
        dataInicio:dataInicio,
        dataFim:dataFim,
        email:email,
        sala: data?.nome,
    });

    useEffect(() => {
        function getReserva() {
            setSala(data?.nome);
        }
        getReserva();
    }, [reserva]);

    useEffect(() => {
        setReserva({
            email,
            dataInicio,
            dataFim,
            sala,
        })
    }, [dataFim, dataInicio, email, sala])

    const sendCreateData = () => {
        insereReservaService(reserva).then((response) => {
            if(response.status === 200)
            {
                alert("Reserva feita!")
                setOpen(false)
            }
            
        }).catch((error) => {
            if(error.response.status === 409) alert("Conflito de datas, sala ocupada.")
        })
    }

    return (
        <Dialog open={open}  onClose={() => setOpen(false)} >
            <DialogTitle>Agendamento de sala: {data?.nome}</DialogTitle>

            <Box sx={{ padding: 5 }}>
                <Grid container spacing={2}>
                    <Grid item xs={12} >
                        <Typography>Data:</Typography>
                    </Grid>
                    <Grid item xs={6}>
                        <TextField
                            type="date"
                            value={dataInicio}
                            onChange={(e) => setDataInicio(e.target.value)}
                            required
                        />
                    </Grid>
                    <Grid item xs={6}>
                        <TextField
                            type="date"
                            value={dataFim}
                            onChange={(e) => setDataFim(e.target.value)}
                            required
                        />
                    </Grid>
                </Grid>
            </Box>

            <Box sx={{ padding: 5 }}>
                <Grid container spacing={2}>
                    <Grid item xs={12} >
                        <Typography>Email:</Typography>
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            type="email"
                            fullWidth
                            label="ogrodaviladeouro@ally.com"
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            required
                        />
                    </Grid>
                </Grid>
            </Box>
            
            <Box sx={{ padding: 2 }}>
                <DialogActions>
                    <Button onClick={() => setOpen(false)} >Cancelar</Button>
                    <Button onClick={() => sendCreateData()} >Salvar</Button>
                </DialogActions>
            </Box>
        </Dialog>
    );
}
