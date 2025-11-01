import * as React from "react";
import Button from "@mui/material/Button";
import Menu from "@mui/material/Menu";
import MenuItem from "@mui/material/MenuItem";
import {
  IconButton,
  ListItemIcon,
  ListItemText,
  MenuList,
} from "@mui/material";
import { Delete, MoreVert } from "@mui/icons-material";

export default function TaskCardMenu({ id = "basic-menu" }) {
  const [anchorEl, setAnchorEl] = React.useState(null);
  const open = Boolean(anchorEl);
  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  return (
    <div>
      <IconButton id={id} onClick={handleClick}>
        <MoreVert fontSize="small" />
      </IconButton>

      <Menu
        id={id}
        anchorEl={anchorEl}
        open={open}
        onClose={handleClose}
        slotProps={{
          list: {
            "aria-labelledby": "basic-button",
          },
        }}
      >
        <MenuItem dense onClick={handleClose}>
          <ListItemIcon>
            <Delete />
          </ListItemIcon>
          <ListItemText>Delete Task</ListItemText>
        </MenuItem>
      </Menu>
    </div>
  );
}
