import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.jsx";
import { BrowserRouter } from "react-router-dom";
import { SnackbarProvider } from "notistack";
import { SuccessSnackbar } from "./Components/Snackbar.jsx";

createRoot(document.getElementById("root")).render(
  <StrictMode>
    <BrowserRouter>
      <SnackbarProvider
        autoHideDuration={3000}
        maxSnack={5}
        anchorOrigin={{ vertical: "bottom", horizontal: "right" }}
        Components={{
          success: SuccessSnackbar,
        }}
      >
        <App />
      </SnackbarProvider>
    </BrowserRouter>
  </StrictMode>
);
