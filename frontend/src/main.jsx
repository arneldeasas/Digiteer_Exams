import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import App from "./App.jsx";
import { BrowserRouter } from "react-router-dom";
import { SnackbarProvider } from "notistack";
import { SuccessSnackbar } from "./Components/Snackbar.jsx";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";

const queryClient = new QueryClient();
createRoot(document.getElementById("root")).render(
  <StrictMode>
    <BrowserRouter>
      <QueryClientProvider client={queryClient}>
        <SnackbarProvider
          autoHideDuration={3000}
          maxSnack={5}
          anchorOrigin={{ vertical: "bottom", horizontal: "right" }}
          Components={{
            success: SuccessSnackbar,
          }}
        >
          <LocalizationProvider dateAdapter={AdapterDayjs}>
            <App />
          </LocalizationProvider>
        </SnackbarProvider>
      </QueryClientProvider>
    </BrowserRouter>
  </StrictMode>
);
