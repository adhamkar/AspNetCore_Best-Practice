import React, { useState } from "react";
import {
    Divider,
  Drawer,
  IconButton,
  List,
  ListItem,
  ListItemText,
  
} from "@mui/material";
import { Link } from "react-router-dom";

import {Menu} from "@mui/icons-material";



function DrawerComponent() {
 
  const [openDrawer, setOpenDrawer] = useState(false);
  return (
    <>
      <Drawer
        open={openDrawer}
        onClose={() => setOpenDrawer(false)}
      >
        <List>
        <ListItem onClick={() => setOpenDrawer(false)}>
            <ListItemText>
              <Link to="/" style={{ textDecoration: "none", color: "blue", fontSize: "20px" }}>Home</Link>
            </ListItemText>
          </ListItem>
          <Divider/>
          <ListItem onClick={() => setOpenDrawer(false)}>
            <ListItemText>
              <Link to="/" style={{ textDecoration: "none", color: "blue", fontSize: "20px" }}>About</Link>
            </ListItemText>
          </ListItem>
          <Divider/>
          <ListItem onClick={() => setOpenDrawer(false)}>
            <ListItemText>
              <Link to="/" style={{ textDecoration: "none", color: "blue", fontSize: "20px" }}>Contact</Link>
            </ListItemText>
          </ListItem>
          <Divider/>
          <ListItem onClick={() => setOpenDrawer(false)}>
            <ListItemText>
              <Link to="/" style={{ textDecoration: "none", color: "blue", fontSize: "20px" }}>Faq</Link>
            </ListItemText>
          </ListItem>
          <Divider/>
        </List>
      </Drawer>
      <IconButton onClick={() => setOpenDrawer(!openDrawer)} sx={{ color: "white" }}>
        <Menu />
      </IconButton>
    </>
  );
}
export default Drawer;