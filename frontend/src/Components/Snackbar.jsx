import { Clear } from "@mui/icons-material";
import { Alert, IconButton } from "@mui/material";
import { useSnackbar } from "notistack";
import React from "react";

const SuccessSnackbar = React.forwardRef((props, ref) => {
  return (
    <Alert
      ref={ref}
      severity="success"
      variant="filled"
      sx={{ width: "100%" }}
      action={<Action id={props.id} />}
    >
      {props?.message}
    </Alert>
  );
});

const Action = ({ id }) => {
  const { closeSnackbar } = useSnackbar();
  return (
    <React.Fragment>
      <IconButton
        size="small"
        aria-label="close"
        color="inherit"
        onClick={(event, reason) => {
          if (reason === "clickaway") return;
          closeSnackbar(id);
        }}
      >
        <Clear fontSize="small" />
      </IconButton>
    </React.Fragment>
  );
};
export { SuccessSnackbar };
