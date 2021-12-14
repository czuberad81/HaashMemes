import React, { Component, useState, useEffect } from 'react';
import { Grid, Button, ButtonGroup, Typography, Input } from "@material-ui/core";
import GroupCell from './GroupCell'
//by adnan
function SearchGroup() {
    const [groupName, setGroupName] = useState('');
    const [groupsList, setGroupList] = useState([]);

    useEffect(() => {
        FetchGroups();
    }, [])

    const JoinGroup = () => {

    }


    const FetchGroups = () => {
        //fetch all groups.
        fetch("http://localhost:5000/api/groups")
            .then(response => response.json())
            .then((data) => {
                setGroupList(data)
            })
    }
    return (
        <Grid item xs={12} spacing={2} align="center">
            <Typography variant="h3" compact="h3">
                <ul>
                    Available Groups:
                    {groupsList.map(group => (
                        <GroupCell groupName={group.groupName} id={group.id}></GroupCell>
                    ))}
                </ul>
            </Typography>
        </Grid>
    );
}

export default SearchGroup; 