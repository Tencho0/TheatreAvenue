import * as React from 'react'
import CircularProgress from '@mui/material/CircularProgress'
import Box from '@mui/material/Box'
import './spinner.scss'

export default function CircularIndeterminate() {
  return (
    <div style={{ position: 'absolute', top: '50%', left: '50%' }}>
      <CircularProgress
        style={{
          width: '80px',
          height: '80px',
          position: 'absolute',
          top: 0,
          left: 0,
        }}
      />
      <div
        style={{
          position: 'fixed',
          top: 0,
          left: 0,
          width: '100%',
          height: '100%',
          backgroundColor: 'rgba(0, 0, 0, 0.5)',
          zIndex: 9999,
        }}
      ></div>
    </div>
  )
}
