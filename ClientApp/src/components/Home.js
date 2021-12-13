import React, { Component, useState } from 'react';
import { Grid, Button, ButtonGroup, Typography, Input } from "@material-ui/core";

function Home() {
  const [name, setName] = useState('');

  const addUser = () => {
    //add user to database using fetch method 
    //then use .then to add user data to local storage (return user in Ok from c#)
    //then navigate user to home screen
  }

  return (
    <Grid container spacing={4} className="center">
      <Grid item xs={12} spacing={2} align="center">
        <Typography variant="h3" compact="h3">
          HashMeme
        </Typography>
        <Grid item xs={12} spacing={4} align="center">
          <Typography variant="h5" compact="h3">
            Enter Your Username
          </Typography>
        </Grid>

      </Grid>

      <Grid item xs={12} align="center">
        <Input placeholder='Enter username' variant="h3" compact="h3" required onChange={(e) => setName(e.target.value)}>
        </Input>
      </Grid>
      <Grid item xs={12} align="center">
        <Button style={{ textDecoration: "none" }} disableElevation variant='contained' color='secondary' onClick={addUser}>
          Join
        </Button>
      </Grid>

    </Grid>
  );
}

export default Home; 