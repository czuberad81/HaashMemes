import React, { Component, useState } from 'react';
import { Grid, Button, ButtonGroup, Typography, Input } from "@material-ui/core";

function GroupCell(props) {

    return (
        <div>
            {props.groupName}
            {props.id}
        </div>
    );
}

export default GroupCell