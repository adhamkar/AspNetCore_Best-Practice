import React from 'react';
import Drawer from './Drawer';
import {
    AppBar,
    Toolbar,
    CssBaseline,
    Typography,
    useTheme,
    useMediaQuery,
    Box,
  } from "@mui/material";
import { Link } from "react-router-dom";

export default function Navbar() {
  const theme = useTheme();
  const isMobile = useMediaQuery(theme.breakpoints.down("md"));

  return (
    <AppBar position="static">
      <CssBaseline />
      <Toolbar>
        <Typography variant="h4"  sx={{ flexGrow: 1, cursor: "pointer" }}>
          Navbar
          
        </Typography>
        {isMobile ? (
          <Drawer />
        ) : (
            <Box sx={{ display: "flex", ml: 5 }}>
            <Link
              to="/"
              style={{
                textDecoration: "none",
                color: "white",
                fontSize: "20px",
                marginLeft: "20px",
                borderBottom: "1px solid transparent",
              }}
              onMouseOver={(e) => (e.currentTarget.style.color = "yellow")}
              onMouseOut={(e) => (e.currentTarget.style.color = "white")}
            >
              Home
            </Link>
            <Link
              to="/about"
              style={{
                textDecoration: "none",
                color: "white",
                fontSize: "20px",
                marginLeft: "20px",
                borderBottom: "1px solid transparent",
              }}
              onMouseOver={(e) => (e.currentTarget.style.color = "yellow")}
              onMouseOut={(e) => (e.currentTarget.style.color = "white")}
            >
              About
            </Link>
            <Link
              to="/contact"
              style={{
                textDecoration: "none",
                color: "white",
                fontSize: "20px",
                marginLeft: "20px",
                borderBottom: "1px solid transparent",
              }}
              onMouseOver={(e) => (e.currentTarget.style.color = "yellow")}
              onMouseOut={(e) => (e.currentTarget.style.color = "white")}
            >
              Contact
            </Link>
            <Link
              to="/faq"
              style={{
                textDecoration: "none",
                color: "white",
                fontSize: "20px",
                marginLeft: "20px",
                borderBottom: "1px solid transparent",
              }}
              onMouseOver={(e) => (e.currentTarget.style.color = "yellow")}
              onMouseOut={(e) => (e.currentTarget.style.color = "white")}
            >
              FAQ
            </Link>
          </Box>
        )}
      </Toolbar>
    </AppBar>
  );
}